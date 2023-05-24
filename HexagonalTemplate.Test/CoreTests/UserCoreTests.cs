using HexagonalTemplate.Cores;
using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
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
            void Act() => userCore.ValidateUser(userEntity);

            // Assert
            AssertNoExceptionThrown(Act);
        }

        [Fact]
        public void ValidateUserAndValidatePassword_NullUserEntity_ThrowsArgumentNullException()
        {
            // Arrange
            UserEntity userEntity = null;

            // Act
            void Act()
            {
                Assert.Throws<ArgumentNullException>("userEntity", () => userCore.ValidateUser(userEntity));
                Assert.Throws<ArgumentNullException>("userEntity", () => userCore.ValidatePassword(userEntity));
            }

            // Assert
            AssertNoExceptionThrown(Act);
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
            void Act() => Assert.Throws<ArgumentException>("userEntity", () => userCore.ValidatePassword(userEntity));

            // Assert
            AssertNoExceptionThrown(Act);
        }

        [Fact]
        public void ValidatePassword_ValidPassword_NoExceptionThrown()
        {
            // Arrange
            var userEntity = CreateUserEntity("test@example.com", "Password123!");

            // Act
            void Act() => userCore.ValidatePassword(userEntity);

            // Assert
            AssertNoExceptionThrown(Act);
        }

        private static void AssertNoExceptionThrown(Action action)
        {
            var exception = Record.Exception(action);
            Assert.Null(exception);
        }
    }
}
