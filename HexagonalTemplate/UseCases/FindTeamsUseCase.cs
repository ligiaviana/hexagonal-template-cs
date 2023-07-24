using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using System.Collections.Generic;
using System.Linq;

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

        public IDictionary<string, object> GetTeams()
        {
            var teams = appRepository.GetTeams();
            if (teams == null)
            {
                return new Dictionary<string, object>
                {
                    { "app_id", 0 },
                    { "users", new List<object>() }
                };
            }

            var users = teams.Select(aut => new Dictionary<string, object>
            {
                { "user_id", aut.UserId.ToString() },
                { "Inicial_date", aut.InicialDate.ToString("dd/MM/yyyy HH:mm:ss") },
                { "active", aut.Active }
            }).ToList();

            return new Dictionary<string, object>
            {
                { "app_id", teams.FirstOrDefault()?.AppId ?? 0 },
                { "users", users }
            };
        }
    }
}
