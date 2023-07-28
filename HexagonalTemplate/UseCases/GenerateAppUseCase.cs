using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;

namespace HexagonalTemplate.UseCases
{
    public class GenerateAppUseCase : IGenerateAppUseCase
    {
        IGenerateAppCore generateAppCore;
        IUserRepository userRepository;
        IAppRepository appRepository;
        IJwtCore jwtCore;
        private readonly IConfiguration configuration;
         

        public GenerateAppUseCase(IGenerateAppCore generateAppCore, IUserRepository userRepository, IAppRepository appRepository, 
            IJwtCore jwtCore, IConfiguration configuration)
        {
            this.generateAppCore = generateAppCore;
            this.userRepository = userRepository;
            this.appRepository = appRepository;
            this.jwtCore = jwtCore;
            this.configuration = configuration;
        }

        public IDictionary<string, object> GenerateNewApp(AppEntity appEntity)
        {
            generateAppCore.ValidateApp(appEntity);
            appRepository.Create(appEntity);
            string key = configuration["Jwt:Key"];
            string issuer = configuration["Jwt:Issuer"];
            var token = jwtCore.GenerateToken(key, issuer);

            return generateAppCore.CreateAppGenerationResult(appEntity.AppId, token);
        }
    }
}
