using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JwtDotNetCore.Services;

namespace JwtDotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class JwtController : Controller
    {
        private readonly ITokenService _tokenService;

        public JwtController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetJwtWithIdClaim([FromBody] string id)
        {
            var token = _tokenService.BuildToken(id);

            return Ok(new { status = "success", token });
        }

        [Authorize]
        [HttpGet]
        public IActionResult ValidateAndRefreshJwt()
        {
            return Ok(new { status = "success" });
        }
    }
}