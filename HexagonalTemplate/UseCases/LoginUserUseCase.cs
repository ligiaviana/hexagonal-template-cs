using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace HexagonalTemplate.UseCases
{
    public class LoginUserUseCase : ILoginUserUseCase
    {
        IUserCore userCore;
        IJwtCore jwtCore;
        IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public LoginUserUseCase(IUserCore userCore, IJwtCore jwtCore, IUserRepository userRepository, IConfiguration configuration)
        {
            this.userCore = userCore;
            this.jwtCore = jwtCore;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        public string Login(UserEntity userEntity)
        {
            userCore.ValidateUser(userEntity);
            var foundUser = userRepository.FindByEmail(userEntity.Email);
            var passwordDb = foundUser.Password;
            jwtCore.Match(userEntity.Password, passwordDb);
            string key = configuration["Jwt:Key"];
            string issuer = configuration["Jwt:Issuer"];
            var token = jwtCore.GenerateToken(key, issuer);

            return token;
        }
    }
}
