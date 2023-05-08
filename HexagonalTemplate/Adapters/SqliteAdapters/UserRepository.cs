using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using Microsoft.EntityFrameworkCore;

namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserDto> Users { get; set; }
    }
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public UserDto Create(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            _context.Users.Add(userDto);
            _context.SaveChanges();

            return userDto;
        }

        public UserDto FindByEmail(UserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (user == null) return null;

            return new UserDto
            {
                Email = user.Email,
                Password = user.Password,
            };
        }

    }
}
