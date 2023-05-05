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
                throw new ArgumentNullException("email should be informed.");

            if (string.IsNullOrEmpty(userDto.Password))
                throw new ArgumentNullException("password should be informed.");
        }

        public void ValidatePassword(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            string password = userDto.Password;

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("The password cannot be empty.", nameof(userDto));

            if (password.Length < 8)
                throw new ArgumentException("The password must have at least 8 characters.", nameof(userDto));

            if (!password.Any(char.IsUpper))
                throw new ArgumentException("The password must have at least one capital letter.", nameof(userDto));

            if (!password.Any(char.IsLower))
                throw new ArgumentException("The Password must have at least one lower case letter.", nameof(userDto));

            if (!password.Any(char.IsDigit))
                throw new ArgumentException("The password must have at least one digit.", nameof(userDto));

            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                throw new ArgumentException("The Password must have at least one special character.", nameof(userDto));
        }
    }
}
