using System;
using System.ComponentModel.DataAnnotations;

namespace CentralizedCachingAPI.Models
{
    public class CacheEntry
    {
        [Key]
        public int Id { get; set; }
        public string RequestKey { get; set; }
        public string ResponseData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Expiration { get; set; }
    }
}
