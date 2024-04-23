using MedicalClinic.Application.DTOs.Identity;
using MedicalClinic.Application.Interfaces.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MedicalClinic.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AccountController(IIdentityService identityService)
        {
            this._identityService = identityService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await _identityService.Register(request));
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Ok(await _identityService.SignIn(request));
        }

        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTokenByRefreshToken(RefreshTokenRequest refreshToken)
        {
            var token = await _identityService.GetTokenByRefresh(refreshToken.RefreshToken);
            return Ok(token);
        }
    }
}






