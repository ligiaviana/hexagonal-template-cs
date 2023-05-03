using HexagonalTemplate.Models.Dtos;

namespace HexagonalTemplate.Ports.Ins
{
    public interface ILoginUseCase
    {
        public string Login(UserDto userDto);
    }
}
