using AnimeICollection.Models.AnimeModel;
using AnimeList.Data;
using AnimeList.DTO;
using AnimeList.Models;
using AnimeList.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static AnimeList.Services.AnimeService;

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
        public async Task<ActionResult<BaseAnimeModelDTO>> GetAnimeById(int animeId)
        {
            var anime = await _animeService.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound();

            var animeDTO = _mapper.Map<BaseAnimeModelDTO>(anime);

            return Ok(animeDTO);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AnimeSearchModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AnimeSearchModel>>> GetAnimeByQuery([FromQuery] AnimeQueryParameters queryParams)
        {
            try
            {
                var animeResponse = await _animeService.GetAnimeWithParametersAsync(queryParams);
                if (animeResponse == null || animeResponse.Data == null || !animeResponse.Data.Any())
                    return NotFound("No anime found with the specified criteria.");

                var animeDTO = _mapper.Map<AnimeSearchModel>(animeResponse);
                return Ok(animeDTO);
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, $"Service unavailable or request failed. Error: {httpEx}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the API. Error: {ex}");
            }
        }
    }

   
}
