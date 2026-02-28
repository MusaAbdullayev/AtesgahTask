using Ecommerse.BL.DTO.User;
using Ecommerse.BL.Service.Interface;
using Ecommerse.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerseAtesgah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            try
            {
                await _service.RegisterAsync(request);
                return Ok(new { Message = "Uğurla qeydiyyatdan keçdi." });
            }
            catch (Exception ex)
            {
                // Servisdə atdığımız exception buraya düşür
                return BadRequest(new { Error = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            try
            {
                var token = await _service.LoginAsync(request);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        [HttpPost("Role")]
        public async Task<IActionResult> Role()
        {
            await _service.Role();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {

            return Ok(await _service.GetUsersAsync());
        }
    }
}
