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

        public UserEntity FindByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public UserEntity FindById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            return user;
        }

        public void DeleteByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
