using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Outs
{
    public interface IUserRepository
    {
        public UserEntity Create(UserEntity userEntity);
        public UserEntity FindByEmail(string email);
    }
}
