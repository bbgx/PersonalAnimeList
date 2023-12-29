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
        private readonly IMapper _mapper;

        public AnimeController(AnimeService animeService, IMapper mapper)
        {
            _animeService = animeService;
            _mapper = mapper;
        }

        [HttpGet("{animeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseAnimeModelDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseAnimeModelDTO>> GetAnimeById(int animeId)
        {
            var anime = await _animeService.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound("Anime not found.");

            var animeDTO = _mapper.Map<BaseAnimeModelDTO>(anime);
            return Ok(animeDTO);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AnimeSearchModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AnimeSearchModel>>> GetAnimeByQuery([FromQuery] AnimeQueryParameters queryParams)
        {
            var animeResponse = await _animeService.GetAnimeWithParametersAsync(queryParams);
            if (animeResponse == null || animeResponse.Data == null || !animeResponse.Data.Any())
                return NotFound("No anime found with the specified criteria.");

            var animeDTO = _mapper.Map<AnimeSearchModel>(animeResponse);
            return Ok(animeDTO);
        }
    }

   
}
