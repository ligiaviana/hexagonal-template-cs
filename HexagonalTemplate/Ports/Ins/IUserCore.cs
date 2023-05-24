using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IUserCore
    {
        public void ValidateUser(UserEntity userEntity);

        public void ValidatePassword(UserEntity userEntity);
    }
}
