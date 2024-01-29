using AnimeICollection.Models.AnimeModel;
using AnimeList.Data;
using AnimeList.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static AnimeList.Models.CharacterModel;

namespace AnimeList.Services
{
    public class CharacterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly AnimeDbContext _dbContext;

        public CharacterService(IHttpClientFactory httpClientFactory, IMapper mapper, AnimeDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<CharacterModel>> GetCharacterByAnimeMalIdAsync (int animeMalId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.jikan.moe/v4/anime/{animeMalId}/characters");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions();
            options.Converters.Add(new CharacterModelConverter());

            var characterDataList = JsonSerializer.Deserialize<List<CharacterModel>>(content, options);
            var charactersToReturn = new List<CharacterModel>();

            var animeInDb = await _dbContext.Animes.FirstOrDefaultAsync(a => a.MalId == animeMalId);

            if (animeInDb != null)
            {
                foreach (var characterData in characterDataList)
                {
                    CharacterModel characterToProcess;

                    var existingCharacter = await _dbContext.Characters
                        .Include(c => c.VoiceActors)
                        .FirstOrDefaultAsync(c => c.MalId == characterData.MalId && c.AnimeId == animeInDb.Id);

                    if (existingCharacter != null)
                    {
                        _mapper.Map(characterData, existingCharacter);
                        characterToProcess = existingCharacter;
                    }
                    else
                    {
                        var newCharacter = _mapper.Map<CharacterModel>(characterData);
                        newCharacter.AnimeId = animeInDb.Id;
                        _dbContext.Characters.Add(newCharacter);
                        characterToProcess = newCharacter;
                    }

                    charactersToReturn.Add(characterToProcess);
                }
            }

            await _dbContext.SaveChangesAsync();
            return charactersToReturn;
        }
    }
}
