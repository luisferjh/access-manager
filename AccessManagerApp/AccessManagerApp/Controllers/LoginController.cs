using AccessManagerApp.DTOs;
using AccessManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AccessManagerApp.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO model)
        {
            AuthenticationResultDTO result = null;
            try
            {
                if (!ModelState.IsValid)                
                    return Unauthorized();

                result = await _userService.LogInUserAsync(model);

                if (result == null)
                    return NotFound();

            }
            catch(Exception ex)
            {
                return Unauthorized();
            }

            return Ok(result.JwtToken);
        }



    }
}
