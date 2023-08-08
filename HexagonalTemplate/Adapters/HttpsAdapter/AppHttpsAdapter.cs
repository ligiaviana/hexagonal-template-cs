using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using HexagonalTemplate.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using Raven.Client.Exceptions;

namespace HexagonalTemplate.Adapters.HttpsAdapter
{
    [ApiController]
    [Route("[controller]")]
    public class AppHttpsAdapter : ControllerBase
    {
        protected IGenerateAppUseCase appUseCase;
        protected IFindAppUseCase findAppUseCase;
        protected IFindTeamsAppUserUseCase findTeamsUseCase;
        protected ICreateTeamsAppUserUseCase createTeamsAppUserUseCase;
        protected IDeleteAppUseCase deleteAppUseCase;
        protected IDeleteTeamsAppUserUseCase deleteTeamsAppUserUseCase;

        public AppHttpsAdapter(IGenerateAppUseCase appUseCase, IFindAppUseCase findAppUseCase, IFindTeamsAppUserUseCase findTeamsUseCase, 
            ICreateTeamsAppUserUseCase createTeamsAppUserUseCase, IDeleteAppUseCase deleteAppUseCase, IDeleteTeamsAppUserUseCase deleteTeamsAppUserUseCase)
        {
            this.appUseCase = appUseCase;
            this.findAppUseCase = findAppUseCase;
            this.findTeamsUseCase = findTeamsUseCase;
            this.createTeamsAppUserUseCase = createTeamsAppUserUseCase;
            this.deleteAppUseCase = deleteAppUseCase;
            this.deleteTeamsAppUserUseCase = deleteTeamsAppUserUseCase;
        }

        [HttpPost("/GenerateApp", Name = "GenerateApp")]
        public ActionResult GenerateApp(AppEntity appEntity)
        {
            try
            {
                var result = appUseCase.GenerateNewApp(appEntity);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(403, ane.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/GetAppById", Name = "GetAppById")]
        public ActionResult GetAppById(int id)
        {
            try
            {
                var app = findAppUseCase.GetAppById(id);
                return Ok(app);
            }
            catch (ArgumentNullException nf)
            {
                return StatusCode(404, nf.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpPost("/CreateTeams", Name = "CreateTeams")]
        public ActionResult CreateTeams(int userId, int appId)
        {
            try
            {
                var appUserTeam = createTeamsAppUserUseCase.CreateTeams(userId, appId);
                return Ok(appUserTeam);
            }
            catch (NotFoundException nf)
            {
                return StatusCode(404, nf.Message);
            }
            catch (ConflictException cf)
            {
                return StatusCode(409, cf.Message);
            }
            catch (ArgumentNullException br)
            {
                return StatusCode(400, br.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                return StatusCode(401, uae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpGet("/GetTeams", Name = "GetTeams")]
        public ActionResult GetTeams()
        {
            try
            {
                var teams = findTeamsUseCase.GetTeams();
                return Ok(teams);
            }
            catch (NotFoundException nf)
            {
                return StatusCode(404, nf.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                return StatusCode(401, uae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("/DeleteAppById", Name = "DeleteAppById")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteAppUseCase.DeleteAppById(id);
                return Ok();
            }
            catch (ArgumentNullException nf)
            {
                return StatusCode(404, nf.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/DeleteTeams", Name = "DeleteTeams")]
        public IActionResult Delete(int userId, int appId)
        {
            try
            {
                deleteTeamsAppUserUseCase.DeleteTeams(userId, appId);
                return Ok();
            }
            catch (ArgumentNullException nf)
            {
                return StatusCode(404, nf.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
