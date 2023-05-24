using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IRegisterUseCase
    {
        public UserEntity Register(UserEntity userEntity);
    }
}
