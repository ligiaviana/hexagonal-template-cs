using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class FindAppUseCase : IFindAppUseCase
    {
        IAppRepository appRepository;

        public FindAppUseCase(IAppRepository appRepository)
        {
            this.appRepository = appRepository;
        }
        public AppEntity GetAppById(int id)
        {

            var app = appRepository.FindById(id);

            if (app == null)
            {
                throw new ArgumentNullException("App not found");
            }
            return app;
        }
    }
}
