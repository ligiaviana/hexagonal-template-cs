using HexagonalTemplate.Models.Dtos;
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
        public string Login(UserDto userDto)
        {
            userCore.ValidateUser(userDto);
            var foundUser = userRepository.FindByEmail(userDto);
            var passwordDb = foundUser.Password;
            jwtCore.Match(userDto.Password, passwordDb);
            var token = jwtCore.GenerateToken(userDto);

            return token;
        }
    }
}
