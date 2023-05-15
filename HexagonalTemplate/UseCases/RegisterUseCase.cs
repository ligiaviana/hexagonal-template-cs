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
        ILogCore logCore;

        public RegisterUseCase(IUserCore userCore, IUserRepository userRepository, ILogCore logCore)
        {
            this.userCore = userCore;
            this.userRepository = userRepository;
            this.logCore = logCore;
        }

        public UserDto Register(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            userCore.ValidateUser(userDto);
            userCore.ValidatePassword(userDto);
            logCore.Log(userDto.Email);
            userRepository.Create(userDto);

            return userDto;
        }

    }
}
