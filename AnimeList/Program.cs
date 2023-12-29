using AnimeICollection.Models.AnimeModel;
using AnimeList.DTO;
using AnimeList.Mapping;
using AnimeList.Middlewares;
using AnimeList.Models;
using AnimeList.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AnimeService>();
builder.Services.AddAutoMapper(typeof(AnimeProfile));
var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<BaseAnimeModel, BaseAnimeModelDTO>();
});

IMapper mapper = config.CreateMapper();
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<AnimeList.Data.AnimeDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<AnimeList.Data.AnimeDbContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying database migrations. Ensure the database is accessible and the connection string is correct. Migrations may also fail if there are schema conflicts or if required permissions are missing. Review the exception details for more information.");
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();