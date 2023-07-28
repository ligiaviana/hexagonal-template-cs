using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Ports.Ins;

namespace HexagonalTemplate.Cores
{
    public class FindTeamsAppUserCore : IFindTeamsAppUserCore
    {
        private readonly AppRepositoryDbContext _appContext;

        public FindTeamsAppUserCore(AppRepositoryDbContext appContext)
        {
            _appContext = appContext;
        }
        public object GetTeams()
        {
            var groupedTeams = _appContext.AppUserTeams
                .GroupBy(team => team.AppId)
                .Select(group => new
                {
                    app_id = group.Key,
                    users = group.Select(team => new
                    {
                        user_id = team.UserId,
                        Inicial_date = team.InicialDate,
                        active = team.Active
                    }).ToList()
                })
                .ToList();

            return groupedTeams;
        }

    }
}
