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
            userRepository.FindByEmail(userDto);
            jwtCore.Match(userDto.Password, userDto.Password);
            var token = jwtCore.GenerateToken(userDto);

            return token;
        }
    }
}
