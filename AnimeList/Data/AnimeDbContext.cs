using AnimeICollection.Models.AnimeModel;
using Microsoft.EntityFrameworkCore;
using static AnimeICollection.Models.AnimeModel.AnimeModel;

namespace AnimeList.Data
{
    public class AnimeDbContext : DbContext
    {
        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options)
        {
        }

        public DbSet<AnimeModel> Animes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ANIME_LIBRARY;User Id=postgres;Password=1234");
        }
    }
}
