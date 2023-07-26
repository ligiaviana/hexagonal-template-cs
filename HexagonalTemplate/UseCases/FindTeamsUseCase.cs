using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;

namespace HexagonalTemplate.UseCases
{
    public class FindTeamsUseCase : IFindTeamsUseCase
    {
        IAppRepository appRepository;
        IUserRepository userRepository;

        public FindTeamsUseCase(IAppRepository appRepository, IUserRepository userRepository)
        {
            this.appRepository = appRepository;
            this.userRepository = userRepository;
        }
        public object GetTeams()
        {
            var teams = appRepository.GetTeams();

            if (teams == null || !teams.Any())
            {
                throw new NotFoundException("Teams not found");
            }

            var groupedTeams = teams.GroupBy(team => team.AppId).ToList();

            var result = new List<object>();

            foreach (var group in groupedTeams)
            {
                var users = group.Select(team => new
                {
                    user_id = team.UserId,
                    Inicial_date = team.InicialDate,
                    active = team.Active
                }).ToList();

                var appTeam = new
                {
                    app_id = group.Key,
                    users
                };

                result.Add(appTeam);
            }

            return result;
        }
    }
}
