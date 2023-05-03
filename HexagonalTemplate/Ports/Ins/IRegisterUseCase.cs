using HexagonalTemplate.Models.Dtos;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IRegisterUseCase
    {
        public UserDto Register(UserDto userDto);
    }
}
