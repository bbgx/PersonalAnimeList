using AnimeList.Data;
using AnimeList.DTO;
using AnimeList.Models;
using Konscious.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace AnimeList.Services
{
    public class AuthService
    {
        private readonly AnimeDbContext _dbContext;
        private readonly int _twoThirdsProcessors = Math.Max(1, (Environment.ProcessorCount * 2) / 3);

        public AuthService(AnimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string HashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(GetArgon2Hash(password, salt));
        }

        public async Task<UserModel?> AuthenticateUser(LoginRequestDTO loginRequest)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (user != null) 
            {
                if (VerifyPassword(loginRequest.Password, user.HashedPassword, user.Salt))
                {
                    return user;
                }
            }

            return null;
        }

        private bool VerifyPassword(string password, string hashedPassword, byte[] salt) 
        {
            var newHash = HashPassword(password, salt);
            return hashedPassword == newHash;
        }

        private byte[] GetArgon2Hash(string password, byte[] salt)
        {
            using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = _twoThirdsProcessors,
                MemorySize = 1024 * 128,
                Iterations = 4
            };

            return argon2.GetBytes(32);
        }

        public byte[] CreateRandomSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var buffer = new byte[32];
                rng.GetBytes(buffer);
                return buffer;
            }
        }
    }
}
