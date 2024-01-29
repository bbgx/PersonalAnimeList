using AnimeICollection.Models.AnimeModel;
using AnimeList.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Data
{
    public class AnimeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AnimeDbContext(DbContextOptions<AnimeDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<AnimeModel> Animes { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CharacterModel> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DevConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
