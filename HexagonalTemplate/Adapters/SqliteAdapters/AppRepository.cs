using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;
using Xamarin.Essentials;

namespace HexagonalTemplate.Adapters.SqliteAdapters
{
    public class AppRepository : IAppRepository
    {
        private readonly AppRepositoryDbContext _appContext;
        private readonly HexagonalDbContext _userContext;

        public AppRepository(AppRepositoryDbContext appContext, HexagonalDbContext userContext)
        {
            _appContext = appContext;
            _userContext = userContext;
        }

        public AppEntity Create(AppEntity appEntity)
        {
            _appContext.Apps.Add(appEntity);
            _appContext.SaveChanges();

            return appEntity;
        }

        public AppEntity FindById(int id)
        {
            var app = _appContext.Apps.FirstOrDefault(u => u.AppId == id);
            return app;
        }

        public bool CheckUserInTeam(int userId, int appId)
        {
            return _appContext.AppUserTeams.Any(aut => aut.UserId == userId && aut.AppId == appId);
        }

        public AppUserTeamEntity GetAppUserTeam(int userId, int appId)
        {
            return _appContext.AppUserTeams.FirstOrDefault(aut => aut.UserId == userId && aut.AppId == appId);
        }

        public void AddUserToTeam(int userId, int appId)
        {
            var user = _userContext.Users.FirstOrDefault(u => u.UserId == userId);

            var app = _appContext.Apps.FirstOrDefault(a => a.AppId == appId);

            var appUserTeam = new AppUserTeamEntity
            {
                UserId = userId,
                AppId = appId,
                User = user,
                App = app
            };

            _appContext.AppUserTeams.Add(appUserTeam);
            _appContext.SaveChanges();
        }

        public List<AppUserTeamEntity> GetTeams()
        {
            return _appContext.AppUserTeams.ToList();
        }

        public void DeleteAppById(int id)
        {
            var app = _appContext.Apps.FirstOrDefault(u => u.AppId == id);

            if (app != null)
            {
                _appContext.Apps.Remove(app);
                _appContext.SaveChanges();
            }
        }

        public void DeleteTeams(int userId, int appId)
        {
            var appTeams = _appContext.AppUserTeams.FirstOrDefault(u => u.UserId == userId && u.AppId == appId);

            if(appTeams != null)
            {
                _appContext.AppUserTeams.Remove(appTeams);
                _appContext.SaveChanges();
            }

        }
    }
}
