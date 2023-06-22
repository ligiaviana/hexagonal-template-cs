using HexagonalTemplate.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class AppRepositoryDbContext : DbContext
    {
        public AppRepositoryDbContext(DbContextOptions<AppRepositoryDbContext> options) : base(options)
        {
        }

        public DbSet<AppEntity> Apps { get; set; }

        public DbSet<ActiveChannelsEntity> ActiveChannels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppEntity>()
                .Ignore(a => a.ActiveChannels);

            base.OnModelCreating(modelBuilder);
        }
    }
}
