using AnimeList.Data;
using AnimeList.DTO;
using AnimeList.Models;
using AnimeList.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly AnimeDbContext _dbContext;

        public AuthController(AuthService authService, AnimeDbContext dbContext)
        {
            _authService = authService;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var salt = _authService.CreateRandomSalt();
            var hashedPassword = _authService.HashPassword(model.Password, salt);

            var user = new UserModel
            {
                Username = model.Username,
                Email = model.Email,
                HashedPassword = hashedPassword,
                Salt = salt,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            var user = await _authService.AuthenticateUser(loginRequest);

            if (user != null) 
            {
                return Ok(new { message = "Login sucessful" });
            };

            return Unauthorized("Invalid username or password");
        }
    }
}
