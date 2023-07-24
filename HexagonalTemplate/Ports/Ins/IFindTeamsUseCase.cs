using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Ins
{
    public interface IFindTeamsUseCase
    {
        public IDictionary<string, object> GetTeams();
    }
}
