using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Models;
using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        IUserCore userCore;
        IUserRepository userRepository;

        public RegisterUseCase(IUserCore userCore, IUserRepository userRepository)
        {
            this.userCore = userCore;
            this.userRepository = userRepository;
        }

        public UserDto Register(UserDto userDto)
        {
            userCore.ValidateUser(userDto);
            Log(userDto.Email);
            userRepository.Create(userDto);

            return userDto;
        }

        private void Log(string msg)
        {
            Console.WriteLine($"Successfuly registered user: {msg}");
        }

    }
}
