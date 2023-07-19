﻿using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using Raven.Client.Exceptions;

namespace HexagonalTemplate.Adapters.HttpsAdapter
{
    [ApiController]
    [Route("[controller]")]
    public class AppHttpsAdapter : ControllerBase
    {
        protected IAppUseCase appUseCase;
        protected IFindAppUseCase findAppUseCase;

        public AppHttpsAdapter(IAppUseCase appUseCase, IFindAppUseCase findAppUseCase)
        {
            this.appUseCase = appUseCase;
            this.findAppUseCase = findAppUseCase;
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

        [HttpPost("/CreateTeams", Name = "CreateTeams")]
        public ActionResult CreateTeams(int userId, int appId)
        {
            try
            {
                var appUserTeam = appUseCase.CreateTeams(userId, appId);
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
    }
}
