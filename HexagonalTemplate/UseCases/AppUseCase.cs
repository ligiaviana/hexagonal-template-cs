using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Cores;
using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class AppUseCase : IAppUseCase
    {
        IAppCore appCore;
        IAppRepository appRepository;
        IJwtCore jwtCore;
        private readonly IConfiguration configuration;

        public AppUseCase(IAppCore appCore, IAppRepository appRepository, IJwtCore jwtCore, IConfiguration configuration)
        {
            this.appCore = appCore;
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
    }
}
