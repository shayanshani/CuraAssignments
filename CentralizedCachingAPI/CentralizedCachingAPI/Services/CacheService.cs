using CentralizedCachingAPI.Data;
using CentralizedCachingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CentralizedCachingAPI.Services
{
    public class CacheService : ICacheService
    {
        private readonly CacheDbContext _context;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(2);

        public CacheService(CacheDbContext context)
        {
            _context = context;
        }

        public async Task<string?> GetFromCacheAsync(string requestKey)
        {
            var cacheEntry = await _context.CacheEntries
                .Where(entry => entry.RequestKey == requestKey && entry.Expiration > DateTime.UtcNow)
                .FirstOrDefaultAsync();

            return cacheEntry?.ResponseData;
        }

        public async Task AddToCacheAsync(string requestKey, string responseData)
        {
            var cacheEntry = new CacheEntry
            {
                RequestKey = requestKey,
                ResponseData = responseData,
                CreatedAt = DateTime.UtcNow,
                Expiration = DateTime.UtcNow.Add(_cacheDuration)
            };

            _context.CacheEntries.Add(cacheEntry);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveExpiredCacheEntriesAsync()
        {
            var expiredEntries = _context.CacheEntries
                .Where(entry => entry.Expiration <= DateTime.UtcNow);
            _context.CacheEntries.RemoveRange(expiredEntries);
            await _context.SaveChangesAsync();
        }
    }
}
