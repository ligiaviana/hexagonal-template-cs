using HexagonalTemplate.Models.Entities;

namespace HexagonalTemplate.Ports.Outs
{
    public interface IAppRepository
    {
        public AppEntity Create(AppEntity appEntity);
        public AppEntity FindById(int id);
        public bool CheckUserInTeam(int userId, int appId);
        public void AddUserToTeam(int userId, int appId);
        public AppUserTeamEntity GetAppUserTeam(int userId, int appId);
        public List<AppUserTeamEntity> GetTeams();
        public void DeleteAppById(int id);
        public void DeleteTeams(int userId, int appId);
    }
}
