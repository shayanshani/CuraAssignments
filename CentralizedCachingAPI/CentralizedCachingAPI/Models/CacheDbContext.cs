using CentralizedCachingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralizedCachingAPI.Data
{
    public class CacheDbContext : DbContext
    {
        public CacheDbContext(DbContextOptions<CacheDbContext> options) : base(options) { }

        public DbSet<CacheEntry> CacheEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure RequestKey is indexed for performance
            modelBuilder.Entity<CacheEntry>()
                .HasIndex(c => c.RequestKey)
                .IsUnique();
        }
    }
}
