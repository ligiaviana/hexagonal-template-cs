using HexagonalTemplate.Models.Dtos;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IUserCore
    {
        public void ValidateUser(UserDto userDto);
    }
}
