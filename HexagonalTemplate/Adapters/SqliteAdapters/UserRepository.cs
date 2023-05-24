using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class UserRepository : IUserRepository
    {
        private readonly HexagonalDbContext _context;
        public UserRepository(HexagonalDbContext context)
        {
            _context = context;
        }
        public UserEntity Create(UserEntity userEntity)
        {
            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return userEntity;
        }

        public UserEntity FindByEmail(UserEntity userEntity)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEntity.Email);
            return user;
        }

    }
}
