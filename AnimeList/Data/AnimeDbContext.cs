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
        public DbSet<AnimeModel.Type> TransmissionMedia { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<PublishingStatus> PublishingStatus { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Licensor> Licensors { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<Streaming> Streamings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ANIME_LIBRARY;User Id=postgres;Password=1234");
        }
    }
}
