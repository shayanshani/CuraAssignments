using System.Threading.Tasks;

namespace CentralizedCachingAPI.Services
{
    public interface ICacheService
    {
        Task<string?> GetFromCacheAsync(string requestKey);
        Task AddToCacheAsync(string requestKey, string responseData);
        Task RemoveExpiredCacheEntriesAsync();
    }
}
