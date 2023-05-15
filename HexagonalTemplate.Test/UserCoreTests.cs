using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using Xunit;
using FluentAssertions;

namespace HexagonalTemplate.Cores.Tests
{
    public class UserCoreTests
    {
        private readonly IUserCore userCore;

        public UserCoreTests()
        {
            userCore = new UserCore();
        }

        [Fact]
        public void ValidateUser_ValidUserDto_NoExceptionThrown()
        {
            // Arrange
            var userDto = new UserDto
            {
                Email = "test@example.com",
                Password = "Password123"
            };

            // Act & Assert
            userCore.Invoking(u => u.ValidateUser(userDto)).Should().NotThrow();
        }

        [Fact]
        public void ValidateUser_NullUserDto_ThrowsArgumentNullException()
        {
            // Arrange
            UserDto userDto = null;

            // Act & Assert
            userCore.Invoking(u => u.ValidateUser(userDto))
                .Should().Throw<ArgumentNullException>()
                .WithParameterName("userDto");
        }

        [Fact]
        public void ValidatePassword_NullUserDto_ThrowsArgumentNullException()
        {
            // Arrange
            UserDto userDto = null;

            // Act & Assert
            userCore.Invoking(u => u.ValidatePassword(userDto))
                .Should().Throw<ArgumentNullException>()
                .WithParameterName("userDto");
        }

        [Theory]
        [InlineData("Pass123")] // Less than 8 characters
        [InlineData("password")] // No uppercase letter
        [InlineData("PASSWORD")] // No lowercase letter
        [InlineData("12345678")] // No special character
        public void ValidatePassword_InvalidPassword_ThrowsArgumentException(string password)
        {
            // Arrange
            var userDto = new UserDto
            {
                Email = "test@example.com",
                Password = password
            };

            // Act & Assert
            userCore.Invoking(u => u.ValidatePassword(userDto))
                .Should().Throw<ArgumentException>()
                .WithParameterName("userDto");
        }

        [Fact]
        public void ValidatePassword_ValidPassword_NoExceptionThrown()
        {
            // Arrange
            var userDto = new UserDto
            {
                Email = "test@example.com",
                Password = "Password123!"
            };

            // Act & Assert
            userCore.Invoking(u => u.ValidatePassword(userDto)).Should().NotThrow();
        }
    }
}

