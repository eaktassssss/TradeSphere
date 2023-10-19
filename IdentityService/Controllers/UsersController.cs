
using Identity.Application.Contract.Request.User;
using Identity.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest createUserRequest)
        {
            var response = await _userService.CreateAsync(createUserRequest);
            return Ok(response);
        }

        [HttpPut]
        [Route("user")]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            var response = await _userService.UpdateAsync(updateUserRequest);
            return Ok(response);
        }


        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetSingleAsync(string id)
        {
            var response = await _userService.GetSingleAsync(id);
            return Ok(response);
        }
    }
}
