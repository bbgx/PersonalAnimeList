using AnimeList.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Applying database migrations...");

var optionsBuilder = new DbContextOptionsBuilder<AnimeDbContext>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ANIME_LIBRARY;User Id=postgres;Password=1234");

using var context = new AnimeDbContext(optionsBuilder.Options);
context.Database.Migrate();

Console.WriteLine("Migrations applied successfully.");