using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAuth.Configurations;
using NetCoreAuth.Models.DataModels;
using NetCoreAuth.Services;

namespace NetCoreAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public User Profile()
        {
            var userId = HttpContext.UserId();


            return _userService.GetProfile(userId);
        }
    }
}