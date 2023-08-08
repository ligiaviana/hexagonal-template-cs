using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class DeleteAppUseCase : IDeleteAppUseCase
    {
        IAppRepository appRepository;

        public DeleteAppUseCase(IAppRepository appRepository)
        {
            this.appRepository = appRepository;
        }

        public void DeleteAppById(int id)
        {
            var app = appRepository.FindById(id);

            if (app == null)
            {
                throw new ArgumentNullException("App not found.");
            }

            appRepository.DeleteAppById(id);
        }
    }
}
