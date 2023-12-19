using AnimeICollection.Models.AnimeModel;
using AnimeList.Data;
using AnimeList.DTO;
using AnimeList.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AnimeController(AnimeService animeService, AnimeDbContext dbContext, IMapper mapper)
        {
            _animeService = animeService;
            _dbContext = dbContext;
            _mapper = mapper;
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
        public async Task<ActionResult<AnimeModelDTO>> GetAnimeById(int animeId)
        {
            var anime = await _animeService.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound();

            var animeDTO = _mapper.Map<AnimeModelDTO>(anime);

            return Ok(animeDTO);
        }
    }
}
