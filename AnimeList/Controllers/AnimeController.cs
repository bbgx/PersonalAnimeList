using AnimeList.Data;
using AnimeList.Models.AnimeModel;
using AnimeList.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AnimeController : ControllerBase
    {
        private readonly AnimeService _animeService;
        private readonly AnimeDbContext _dbContext;

        public AnimeController(AnimeService animeService, AnimeDbContext dbContext)
        {
            _animeService = animeService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves a specific anime by ID.
        /// </summary>
        /// <param name="animeId">The ID of the anime to retrieve.</param>
        /// <returns>An anime object.</returns>
        [HttpGet("{animeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimeModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAnimeById(int animeId)
        {
            var anime = await _animeService.GetAnimeByIdAsync(animeId);
            _dbContext.Animes.Add(anime);
            await _dbContext.SaveChangesAsync();
            return Ok(anime);
        }
    }
}
