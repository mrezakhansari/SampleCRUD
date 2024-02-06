using Microsoft.AspNetCore.Mvc;
using SampleCRUD.Identity.Models;
using SampleCRUD.Identity.Services;

namespace SampleCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }
    }
}
