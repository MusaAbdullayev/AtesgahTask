using Ecommerse.BL.DTO.User;
using Ecommerse.BL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerseAtesgah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _service.RegisterAsync(dto);
            return Created();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            return Ok(await _service.LoginAsync(dto));
        }
    }
}
