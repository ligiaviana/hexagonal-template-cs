using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using HexagonalTemplate.UseCases;
using Moq;

namespace HexagonalTemplate.Test
{
    public class RegisterUseCaseTests
    {
        [Fact]
        public void Register_ValidUserDto_CallsValidationMethodsAndRepositoryCreate()
        {
            // Arrange
            var userDto = new UserDto
            {
                Email = "test@example.com",
                Password = "password123"
            };

            var userCoreMock = new Mock<IUserCore>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var logCoreMock = new Mock<ILogCore>();

            var registerUseCase = new RegisterUseCase(userCoreMock.Object, userRepositoryMock.Object, logCoreMock.Object);

            // Act
            var result = registerUseCase.Register(userDto);

            // Assert
            userCoreMock.Verify(uc => uc.ValidateUser(userDto), Times.Once);
            userCoreMock.Verify(uc => uc.ValidatePassword(userDto), Times.Once);
            userRepositoryMock.Verify(ur => ur.Create(userDto), Times.Once);

            Assert.Same(userDto, result);
        }

        [Fact]
        public void Register_NullUserDto_ThrowsArgumentNullException()
        {
            // Arrange
            var userCoreMock = new Mock<IUserCore>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var logCoreMock = new Mock<ILogCore>();

            var registerUseCase = new RegisterUseCase(userCoreMock.Object, userRepositoryMock.Object, logCoreMock.Object);

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => registerUseCase.Register(null));
            Assert.Equal("userDto", exception.ParamName);
        }
    }
}
