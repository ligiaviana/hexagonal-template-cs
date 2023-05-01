using HexagonalTemplate.Models;

namespace HexagonalTemplate.Ports
{
    public interface IRegisterUseCase
    {
        public UserDto Register(UserDto userDto);
    }
}
