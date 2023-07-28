using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;

namespace HexagonalTemplate.Cores
{
    public class CreateTeamsAppUserCore : ICreateTeamsAppUserCore
    {
        IUserRepository userRepository;
        IAppRepository appRepository;

        public CreateTeamsAppUserCore(IUserRepository userRepository, IAppRepository appRepository)
        {
            this.userRepository = userRepository;
            this.appRepository = appRepository;
        }

        public object CreateTeams(int userId, int appId)
        {
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
