using Microsoft.AspNetCore.Mvc;
using SpendWise.API.DTOs;
using SpendWise.API.Repository.IRepo;
using System.Net;

namespace SpendWise.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request data.");

            var result = await _userRepository.RegisterAsync(dto);

            if (result == null)
                return BadRequest("User registration failed. Please try again.");

            return StatusCode((int)HttpStatusCode.Created, new { message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request data.");

            var result = await _userRepository.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Invalid email or password");

            return Ok(new { message = "Login successful", token = result });
        }
    }
}
