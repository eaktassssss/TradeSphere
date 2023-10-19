using Identity.Application.Contract.Request.Token;
using Identity.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        [Route("authentication")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTokenRequest createTokenRequest)
        {
            var response = await _authenticationService.CreateTokenAsync(createTokenRequest);
            return Ok(response);
        }
    }
}
