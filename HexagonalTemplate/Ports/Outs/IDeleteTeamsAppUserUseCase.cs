namespace HexagonalTemplate.Ports.Outs
{
    public interface IDeleteTeamsAppUserUseCase
    {
        public void DeleteTeams(int userId, int appId);
    }
}
