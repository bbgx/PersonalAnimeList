using AnimeList.Mapping;
using AnimeList.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AnimeService>();
builder.Services.AddAutoMapper(typeof(AnimeProfile));
var connectionString = builder.Configuration.GetConnectionString("Host=localhost;Port=5432;Pooling=true;Database=ANIME_LIBRARY;User Id=postgres;Password=1234");
builder.Services.AddDbContext<AnimeList.Data.AnimeDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();