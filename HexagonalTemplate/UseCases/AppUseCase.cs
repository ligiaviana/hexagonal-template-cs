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

        public dynamic GenerateNewApp(AppEntity appEntity)
        {
            appCore.ValidateApp(appEntity);
            appRepository.Create(appEntity);
            string key = configuration["Jwt:Key"];
            string issuer = configuration["Jwt:Issuer"];
            var token = jwtCore.GenerateToken(key, issuer);

            return new
            {
                AppId = appEntity.AppId,
                AppToken = token
            };
        }

    }
}
