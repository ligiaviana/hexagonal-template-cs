using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class UserCore : IUserCore
    {
        public void ValidateUser(UserEntity userEntity)
        {
            if (userEntity == null)
                throw new ArgumentNullException(nameof(userEntity));

            if (string.IsNullOrEmpty(userEntity.Email))
                throw new ArgumentNullException("email should be informed.");

            if (string.IsNullOrEmpty(userEntity.Password))
                throw new ArgumentNullException("password should be informed.");
        }

        public void ValidatePassword(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException(nameof(userEntity));
            }
            string password = userEntity.Password;

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("The password cannot be empty.", nameof(userEntity));

            if (password.Length < 8)
                throw new ArgumentException("The password must have at least 8 characters.", nameof(userEntity));

            if (!password.Any(char.IsUpper))
                throw new ArgumentException("The password must have at least one capital letter.", nameof(userEntity));

            if (!password.Any(char.IsLower))
                throw new ArgumentException("The Password must have at least one lower case letter.", nameof(userEntity));

            if (!password.Any(char.IsDigit))
                throw new ArgumentException("The password must have at least one digit.", nameof(userEntity));

            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                throw new ArgumentException("The Password must have at least one special character.", nameof(userEntity));
        }
    }
}
