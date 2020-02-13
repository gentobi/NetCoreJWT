using Microsoft.AspNetCore.Mvc;
using NetCoreAuth.Models.ViewModels;
using NetCoreAuth.Services;

namespace NetCoreAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authService;
        public AuthenticationController()
        {
            _authService = new AuthenticationService();
        }

        [HttpPost]
        public string Authenticate([FromBody] AuthenticationModel input)
        {
            return _authService.Authenticate(input);
        }
    }
}