using BallastLaneTest.BusinessLogic;
using BallastLaneTest.BusinessLogic.Interfaces;
using BallastLaneTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BallastLaneTest.API.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private ILogicUser userInstance;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            userInstance = (new BLFactory()).getLogicUser();
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                var result = userInstance.CreateUser(user);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AuthenticateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Authenticate([FromBody] Login login)
        {
            try
            {
                var result = userInstance.AuthenticateUser(login);
                return Ok(new { result });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}