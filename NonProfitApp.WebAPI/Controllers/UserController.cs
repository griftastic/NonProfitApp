using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonProfitApp.Data;

namespace NonProfitApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registerResult = await _userService.RegisterUserAsync(model);
            if(registerResult)
            {
                return Ok("User was registered.");
            }
            return BadRequest("User could not be registered.");
        }
    }
}