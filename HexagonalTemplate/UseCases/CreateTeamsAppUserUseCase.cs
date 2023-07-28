using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using OpenQA.Selenium;
using System;

namespace HexagonalTemplate.UseCases
{
    public class CreateTeamsAppUserUseCase : ICreateTeamsAppUserUseCase
    {
        ICreateTeamsAppUserCore createTeamsAppUserCore;
        IAppRepository appRepository;
        private readonly AppRepositoryDbContext _appContext;
        private readonly HexagonalDbContext _userContext;

        public CreateTeamsAppUserUseCase(ICreateTeamsAppUserCore createTeamsAppUserCore, IAppRepository appRepository,
            AppRepositoryDbContext appContext, HexagonalDbContext userContext)
        {
            this.createTeamsAppUserCore = createTeamsAppUserCore;
            this.appRepository = appRepository;
            _appContext = appContext;
            _userContext = userContext;
        }
        public object CreateTeams(int userId, int appId)
        {
            var user = _userContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            var app = _appContext.Apps.FirstOrDefault(a => a.AppId == appId);
            if (app == null)
            {
                throw new NotFoundException("App not found.");
            }

            createTeamsAppUserCore.CreateTeams(userId, appId);
         
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
