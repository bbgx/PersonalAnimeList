using AnimeICollection.Models.AnimeModel;
using Microsoft.EntityFrameworkCore;
using static AnimeICollection.Models.AnimeModel.AnimeModel;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DevConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
