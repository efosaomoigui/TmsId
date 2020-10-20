using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TmsId.Api.Services;
using TmsId.Shared;

namespace TmsId.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;

        }

        //Register Users
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Your inputs are not valid");
        }

        //Register Users
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Your inputs are not valid");
        }

    }
}
