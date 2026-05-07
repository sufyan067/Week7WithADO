using Microsoft.AspNetCore.Mvc;
using Week7WithADO.Models.User;
using Week7WithADO.Services;

namespace Week7WithADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service) 
        {
            _service = service;

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var token = await _service.Login(model.Username, model.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}
