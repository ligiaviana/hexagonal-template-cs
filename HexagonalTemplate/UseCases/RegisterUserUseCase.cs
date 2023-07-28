using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        IUserCore userCore;
        IUserRepository userRepository;
        ILogCore logCore;

        public RegisterUserUseCase(IUserCore userCore, IUserRepository userRepository, ILogCore logCore)
        {
            this.userCore = userCore;
            this.userRepository = userRepository;
            this.logCore = logCore;
        }

        public UserEntity Register(UserEntity userEntity)
        {
            userCore.ValidateUser(userEntity);
            userCore.ValidatePassword(userEntity);
            logCore.Log(userEntity.Email);
            userRepository.Create(userEntity);

            return userEntity;
        }

    }
}
