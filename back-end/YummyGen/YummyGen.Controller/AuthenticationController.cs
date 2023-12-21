using Microsoft.AspNetCore.Mvc;
using YummyGen.Domain;
using YummyGen.Domain.Dto;
using YummyGen.Domain.Interfaces;

namespace YummyGen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login([FromBody] LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await authenticationService.Login(loginDto);
                return Ok(loginResult);
            }

            return BadRequest("Login has failed");
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = await authenticationService.Register(registerDto);
                return Ok(user);
            }

            return BadRequest("Registration has failed");
        }
    }
}
