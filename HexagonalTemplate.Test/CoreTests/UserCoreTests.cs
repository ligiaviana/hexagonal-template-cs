using HexagonalTemplate.Cores;
using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using FluentAssertions;
using Xunit;

namespace HexagonalTemplate.Test.CoreTests
{
    public class UserCoreTests
    {
        private readonly IUserCore userCore;

        public UserCoreTests()
        {
            userCore = new UserCore();
        }

        private UserEntity CreateUserEntity(string email, string password)
        {
            return new UserEntity
            {
                Email = email,
                Password = password
            };
        }

        [Fact]
        public void ValidateUser_ValidUserEntity_NoExceptionThrown()
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", "Password123");

            // Act
            Action act = () => userCore.ValidateUser(userEntity);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ValidateUserAndValidatePassword_NullUserEntity_ThrowsArgumentNullException()
        {
            // Arrange
            UserEntity userEntity = null;

            // Act
            Action act = () => userCore.ValidateUser(userEntity);
            Action act2 = () => userCore.ValidatePassword(userEntity);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("userEntity");
            act2.Should().Throw<ArgumentNullException>()
                .WithParameterName("userEntity");
        }

        [Theory]
        [InlineData("Pass123")] // Less than 8 characters
        [InlineData("password")] // No uppercase letter
        [InlineData("PASSWORD")] // No lowercase letter
        [InlineData("12345678")] // No special character
        public void ValidatePassword_InvalidPassword_ThrowsArgumentException(string password)
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", password);

            // Act
            Action act = () => userCore.ValidatePassword(userEntity);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithParameterName("userEntity");
        }

        [Fact]
        public void ValidatePassword_ValidPassword_NoExceptionThrown()
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", "Password123!");

            // Act
            Action act = () => userCore.ValidatePassword(userEntity);

            // Assert
            act.Should().NotThrow();
        }
    }
}
