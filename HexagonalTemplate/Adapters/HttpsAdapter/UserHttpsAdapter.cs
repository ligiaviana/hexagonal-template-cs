using HexagonalTemplate.Models;
using HexagonalTemplate.Ports;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalTemplate.Adapters.HttpsAdapter
{
    [ApiController]
    [Route("[controller]")]
    public class UserHttpsAdapter : ControllerBase
    {
        protected IRegisterUseCase registerUseCase;

        public UserHttpsAdapter(IRegisterUseCase registerUseCase)
        {
            this.registerUseCase = registerUseCase;
        }

        [HttpPost("/Register", Name = "Register")]

        public ActionResult Register(UserDto userDto)
        {
            try
            {
                var userRequestDto = registerUseCase.Register(userDto);
                return Ok(userRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
