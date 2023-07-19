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
        public DbSet<AppUserTeamEntity> AppUserTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppEntity>().HasKey(a => a.AppId);
            modelBuilder.Entity<AppUserTeamEntity>().HasKey(aut => new { aut.AppId, aut.UserId });

            modelBuilder.Entity<AppUserTeamEntity>()
                .HasOne(aut => aut.App)
                .WithMany()
                .HasForeignKey(aut => aut.AppId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
