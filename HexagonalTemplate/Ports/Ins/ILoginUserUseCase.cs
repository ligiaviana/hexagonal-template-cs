using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface ILoginUserUseCase
    {
        public string Login(UserEntity userEntity);
    }
}
