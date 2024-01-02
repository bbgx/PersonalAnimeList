using AnimeList.Data;
using AnimeList.DTO;
using AnimeList.Models;
using AnimeList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly AnimeDbContext _dbContext;
        private readonly TokenService _tokenService;

        public AuthController(AuthService authService, AnimeDbContext dbContext, TokenService tokenService)
        {
            _authService = authService;
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var existingUser = await _dbContext.Users
                .AnyAsync(u => u.Username == model.Username || u.Email == model.Email);

            if (existingUser)
            {
                return BadRequest("Username or email already in use.");
            }

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
            var getUser = await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (getUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var user = await _authService.AuthenticateUser(loginRequest);

            if (user != null) 
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(new { token });
            };

            return Unauthorized("Invalid username or password");
        }
    }
}
