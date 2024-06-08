using Microsoft.AspNetCore.Mvc;

namespace CentralizedCachingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            // Simulate a complex calculation or data fetch
            await Task.Delay(500);
            var result = new { Id = id, Value = $"Complex calculation result for {id}" };

            return Ok(result);
        }
    }
}
