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
        int twoThirdsProcessors = Math.Max(1, (Environment.ProcessorCount * 2) / 3);

        public AuthService(AnimeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string HashPassword(string password, byte[] salt)
        {
            using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = twoThirdsProcessors;
            argon2.MemorySize = 1024 * 128;
            argon2.Iterations = 4;

            return Convert.ToBase64String(argon2.GetBytes(32));
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
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes;

            using (var argon2 = new Argon2id(passwordBytes))
            {
                argon2.Salt = salt;
                argon2.DegreeOfParallelism = twoThirdsProcessors;
                argon2.MemorySize = 1024 * 128;
                argon2.Iterations = 4;

                hashBytes = argon2.GetBytes(32);
            };
            string newHash = Convert.ToBase64String(hashBytes);

            return hashedPassword == newHash;
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
