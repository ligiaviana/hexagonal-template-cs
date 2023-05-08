using HexagonalTemplate.Models.Dtos;

namespace HexagonalTemplate.Ports.Outs
{
    public interface IUserRepository
    {
        UserDto Create(UserDto userDto);
        public UserDto FindByEmail(UserDto userDto);
    }
}
