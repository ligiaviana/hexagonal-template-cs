using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class UserCore : IUserCore
    {
        public void ValidateUser(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            if (string.IsNullOrEmpty(userDto.Email))
                throw new ArgumentNullException("email should be informed");

            if (string.IsNullOrEmpty(userDto.Password))
                throw new ArgumentNullException("password should be informed");
        }
    }
}
