using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IRegisterUserUseCase
    {
        public UserEntity Register(UserEntity userEntity);
    }
}
