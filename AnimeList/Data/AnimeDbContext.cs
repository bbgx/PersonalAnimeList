using Microsoft.EntityFrameworkCore;
using AnimeList.Models.AnimeModel;

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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=MOVIE_LIBRARY;User Id=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Demographics)
                .WithOne();

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.ExplicitGenres)
                .WithOne();

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Genres)
                .WithOne();

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Studios)
                .WithOne();

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Themes)
                .WithOne();

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Producers)
                .WithOne(p => p.DataForProducers)
                .HasForeignKey(p => p.DataIdForProducers);

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Licensors)
                .WithOne(l => l.DataForLicensors)
                .HasForeignKey(l => l.DataIdForLicensors);

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Studios)
                .WithOne(s => s.DataForStudios)
                .HasForeignKey(s => s.DataIdForStudios);

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Genres)
                .WithOne() // Assuming no inverse navigation
                .HasForeignKey(g => g.DataIdForGenres); // Assuming this foreign key exists

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.ExplicitGenres)
                .WithOne() // Assuming no inverse navigation
                .HasForeignKey(e => e.DataIdForExplicitGenres); // Assuming this foreign key exists

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Themes)
                .WithOne() // Assuming no inverse navigation
                .HasForeignKey(t => t.DataIdForThemes); // Assuming this foreign key exists

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.Demographics)
                .WithOne() // Assuming no inverse navigation
                .HasForeignKey(d => d.DataIdForDemographics); // Assuming this foreign key exists

            modelBuilder.Entity<AnimeList.Models.AnimeModel.Data>()
                .HasMany(d => d.External)
                .WithOne(e => e.Data)
                .HasForeignKey(e => e.EDataId);

        }
    }
}
