using MessagesAPI.DTOS;
using MessagesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessagesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                var loggedIn = await _service.Login(login.Username, login.Password);
                if (loggedIn) return Ok(loggedIn);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging in");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}