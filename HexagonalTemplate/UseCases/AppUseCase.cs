using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;

namespace HexagonalTemplate.UseCases
{
    public class AppUseCase : IAppUseCase
    {
        IAppCore appCore;
        IUserRepository userRepository;
        IAppRepository appRepository;
        IJwtCore jwtCore;
        private readonly IConfiguration configuration;
         

        public AppUseCase(IAppCore appCore, IUserRepository userRepository, IAppRepository appRepository, 
            IJwtCore jwtCore, IConfiguration configuration)
        {
            this.appCore = appCore;
            this.userRepository = userRepository;
            this.appRepository = appRepository;
            this.jwtCore = jwtCore;
            this.configuration = configuration;
        }

        public IDictionary<string, object> GenerateNewApp(AppEntity appEntity)
        {
            appCore.ValidateApp(appEntity);
            appRepository.Create(appEntity);
            string key = GetJwtKeyFromAppSettingsJson();
            string issuer = GetJwtIssuerFromAppSettingsJson();
            var token = jwtCore.GenerateToken(key, issuer);

            return CreateAppGenerationResult(appEntity.AppId, token);
        }

        private string GetJwtKeyFromAppSettingsJson()
        {
            return configuration["Jwt:Key"];
        }

        private string GetJwtIssuerFromAppSettingsJson()
        {
            return configuration["Jwt:Issuer"];
        }

        private IDictionary<string, object> CreateAppGenerationResult(int appId, string appToken)
        {
                return new Dictionary<string, object>
                {
                    { "AppId", appId },
                    { "AppToken", appToken }
                };
        }

        public object CreateTeams(int userId, int appId)
        {
            var user = userRepository.FindById(userId);
            var app = appRepository.FindById(appId);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            if (app == null)
            {
                throw new NotFoundException("App not found");
            }

            bool userInTeam = appRepository.CheckUserInTeam(userId, appId);
            if (userInTeam)
            {
                throw new InvalidOperationException("User is already in the team.");
            }

            appRepository.AddUserToTeam(userId, appId);

            var appUserTeam = appRepository.GetAppUserTeam(userId, appId);

            return new
            {
                user_id = appUserTeam.UserId,
                app_id = appUserTeam.AppId,
                Inicial_date = appUserTeam.InicialDate,
                active = appUserTeam.Active
            };
        }
    }
}
