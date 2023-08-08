using HexagonalTemplate.Ports.Outs;

namespace HexagonalTemplate.UseCases
{
    public class DeleteTeamsAppUserUseCase : IDeleteTeamsAppUserUseCase
    {
        IAppRepository appRepository;

        public DeleteTeamsAppUserUseCase(IAppRepository appRepository)
        {
            this.appRepository = appRepository;
        }

        public void DeleteTeams(int userId, int appId) 
        {
            var teams = appRepository.GetAppUserTeam(userId, appId);

            if(teams == null)
            {
                throw new ArgumentNullException("Team not found.");
            }

            appRepository.DeleteTeams(userId, appId); 
        }
        
    }
}
