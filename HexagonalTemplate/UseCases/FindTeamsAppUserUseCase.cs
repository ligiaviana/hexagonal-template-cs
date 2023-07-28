using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;

namespace HexagonalTemplate.UseCases
{
    public class FindTeamsAppUserUseCase : IFindTeamsAppUserUseCase
    {
        IFindTeamsAppUserCore findTeamsAppUserCore;
        public FindTeamsAppUserUseCase(IFindTeamsAppUserCore findTeamsAppUserCore)
        {
            this.findTeamsAppUserCore = findTeamsAppUserCore;
        }
        public object GetTeams()
        {
            var teams = findTeamsAppUserCore.GetTeams();
            return teams;
        }
    }
}
