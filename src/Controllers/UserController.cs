using Microsoft.AspNetCore.Mvc;
using Siemens.Helper;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Siemens.Service;
using Siemens.Model.User;

namespace Siemens.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public UserController(
            IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.username, model.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            // return basic user info and authentication token
            return Ok(new
            {
                id = user.id,
                username = user.username,
                userType=user.userType
            });
        }
    }
}