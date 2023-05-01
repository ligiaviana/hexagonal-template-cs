using HexagonalTemplate.Models;
using HexagonalTemplate.Ports;

namespace HexagonalTemplate.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        public UserDto Register(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var newUser = new User
            {
                Email = userDto.Email,
                Password = userDto.Password
            };

            Console.WriteLine($"Successfuly registered user: {newUser.Email}");

            var createdUserDto = new UserDto
            {
                Email = newUser.Email,
                Password = newUser.Password
            };

            return createdUserDto;
        }
    }
}
