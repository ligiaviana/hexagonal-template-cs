using HexagonalTemplate.Models.Dtos;
using HexagonalTemplate.Ports.Ins;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Adapters.HttpsAdapter
{
    [ApiController]
    [Route("[controller]")]
    public class UserHttpsAdapter : ControllerBase
    {
        protected IRegisterUseCase registerUseCase;
        protected ILoginUseCase loginUseCase;

        public UserHttpsAdapter(IRegisterUseCase registerUseCase, ILoginUseCase loginUseCase)
        {
            this.registerUseCase = registerUseCase;
            this.loginUseCase = loginUseCase;
        }

        [HttpPost("/Register", Name = "Register")]

        public ActionResult Register(UserDto userDto)
        {
            try
            {
                var userRequestDto = registerUseCase.Register(userDto);
                return Ok(userRequestDto);
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

        public ActionResult Login(UserDto userDto)
        {
            try
            {
                var result = loginUseCase.Login(userDto);
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
