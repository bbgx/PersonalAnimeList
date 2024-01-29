using AnimeList.DTO;
using AnimeList.Models;
using AnimeList.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AnimeList.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(CharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet("{animeMalId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CharacterDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<CharacterDTO>>> GetCharactersByAnime(int animeMalId)
        {
            var characters = await _characterService.GetCharacterByAnimeMalIdAsync(animeMalId);
            if (characters == null || !characters.Any())
            {
                return NotFound();
            }
            var charactersDTO = _mapper.Map<List<CharacterDTO>>(characters);

            return Ok(charactersDTO);
        }
    }
}
