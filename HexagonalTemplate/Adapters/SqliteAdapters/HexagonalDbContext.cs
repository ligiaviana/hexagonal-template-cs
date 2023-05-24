using HexagonalTemplate.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class HexagonalDbContext : DbContext
    {
        public HexagonalDbContext(DbContextOptions<HexagonalDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
