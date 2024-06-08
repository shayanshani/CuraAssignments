using CentralizedCachingAPI.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralizedCachingAPI.Middleware
{
    public class CacheMiddleware
    {
        private readonly RequestDelegate _next;

        public CacheMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICacheService cacheService)
        {
            // Access scoped services directly using HttpContext
            var requestKey = CreateRequestKey(context.Request);

            var cachedResponse = await cacheService.GetFromCacheAsync(requestKey);
            if (cachedResponse != null)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(cachedResponse);
                return;
            }

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                await cacheService.AddToCacheAsync(requestKey, responseText);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private string CreateRequestKey(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Method}:{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(k => k.Key))
            {
                keyBuilder.Append($"|{key}={value}");
            }

            return keyBuilder.ToString();
        }
    }
}
