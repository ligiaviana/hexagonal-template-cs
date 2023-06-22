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
        IAppJwtCore appJwtCore;

        public AppUseCase(IAppCore appCore, IAppRepository appRepository, IAppJwtCore appJwtCore)
        {
            this.appCore = appCore;
            this.appRepository = appRepository;
            this.appJwtCore = appJwtCore;
        }

        public string GenerateNewApp(AppEntity appEntity)
        {
            appCore.ValidateApp(appEntity);
            appRepository.Create(appEntity);
            var token = appJwtCore.GenerateToken(appEntity);

            return token;
        }

    }
}
