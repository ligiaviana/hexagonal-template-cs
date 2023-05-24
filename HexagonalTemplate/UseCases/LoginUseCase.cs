using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        IUserCore userCore;
        IJwtCore jwtCore;
        IUserRepository userRepository;

        public LoginUseCase(IUserCore userCore, IJwtCore jwtCore, IUserRepository userRepository)
        {
            this.userCore = userCore;
            this.jwtCore = jwtCore;
            this.userRepository = userRepository;
        }
        public string Login(UserEntity userEntity)
        {
            userCore.ValidateUser(userEntity);
            var foundUser = userRepository.FindByEmail(userEntity.Email);
            var passwordDb = foundUser.Password;
            jwtCore.Match(userEntity.Password, passwordDb);
            var token = jwtCore.GenerateToken(userEntity);

            return token;
        }
    }
}
