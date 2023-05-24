using HexagonalTemplate.Models.Entities;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Adapters.HttpsAdapter
{
    [ApiController]
    [Route("[controller]")]
    public class UserHttpsAdapter : ControllerBase
    {
        protected IRegisterUseCase registerUseCase;
        protected ILoginUseCase loginUseCase;
        protected IUserRepository userRepository;
        protected IFindUseCase findUseCase;

        public UserHttpsAdapter(IRegisterUseCase registerUseCase, ILoginUseCase loginUseCase, IUserRepository userRepository, IFindUseCase findUseCase)
        {
            this.registerUseCase = registerUseCase;
            this.loginUseCase = loginUseCase;
            this.userRepository = userRepository;
            this.findUseCase = findUseCase;
        }


        [HttpGet("/GetById", Name = "GetById")]

        public ActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = findUseCase.GetUserByEmail(email);
                return Ok(user);
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

        [HttpPost("/Register", Name = "Register")]

        public ActionResult Register(UserEntity userEntity)
        {
            try
            {
                var userRequestEntity = registerUseCase.Register(userEntity);
                return Ok(userRequestEntity);
            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(406, ane.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("/Login", Name = "Login")]

        public ActionResult Login(UserEntity userEntity)
        {
            try
            {
                var result = loginUseCase.Login(userEntity);
                return Ok(result);

            }
            catch (ArgumentNullException ane)
            {
                return StatusCode(406, ane.Message);
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
