using AnimeICollection.Models.AnimeModel;
using AnimeList.Data;
using AnimeList.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;


namespace AnimeList.Services
{
    public class AnimeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly AnimeDbContext _dbContext;

        public AnimeService(IHttpClientFactory httpClientFactory, IMapper mapper, AnimeDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<AnimeModel> GetAnimeByIdAsync (int animeId)
        {
            var existingAnime = await _dbContext.Animes.FirstOrDefaultAsync(anime => anime.MalId == animeId);

            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnimeModelConverter());

            if (existingAnime != null)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://api.jikan.moe/v4/anime/{animeId}/full");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var newAnimeData = JsonSerializer.Deserialize<AnimeModel>(content, options);
                if (IsAnimeUpdated(existingAnime, newAnimeData))
                {
                    await UpdateAnimeAsync(existingAnime, newAnimeData);
                }

                existingAnime.MediaProducers = await FetchAndAssociateEntities(newAnimeData.MediaProducers, x => x.MalId, "MalId");
                existingAnime.MediaStudios = await FetchAndAssociateEntities(newAnimeData.MediaStudios, x => x.MalId, "MalId");
                existingAnime.MediaLicensors = await FetchAndAssociateEntities(newAnimeData.MediaLicensors, x => x.MalId, "MalId");
                existingAnime.MediaGenres = await FetchAndAssociateEntities(newAnimeData.MediaGenres, x => x.MalId, "MalId");
                existingAnime.MediaThemes = await FetchAndAssociateEntities(newAnimeData.MediaThemes, x => x.MalId, "MalId");
                existingAnime.MediaDemographics = await FetchAndAssociateEntities(newAnimeData.MediaDemographics, x => x.MalId, "MalId");
                existingAnime.StreamingWebsites = await FetchAndAssociateEntities(newAnimeData.StreamingWebsites, x => x.Name, "Name");

                return existingAnime;
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://api.jikan.moe/v4/anime/{animeId}/full");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var newAnimeData = JsonSerializer.Deserialize<AnimeModel>(content, options);
                _dbContext.Animes.Add(newAnimeData);
                await _dbContext.SaveChangesAsync();

                return newAnimeData;
            }
        }

        private async Task UpdateAnimeAsync(AnimeModel existingAnime, AnimeModel newAnimeData)
        {
            _mapper.Map(newAnimeData, existingAnime);
            await _dbContext.SaveChangesAsync();
        }

        private bool IsAnimeUpdated(AnimeModel existingAnime, AnimeModel newAnimeData)
        {
            bool isUpdated = false;

            foreach (PropertyInfo property in typeof(AnimeModel).GetProperties())
            {
                if (property.Name == "Id" || property.PropertyType.GetInterface(nameof(IEnumerable)) != null)
                    continue;

                var oldValue = property.GetValue(existingAnime);
                var newValue = property.GetValue(newAnimeData);

                if (newValue != null && !newValue.Equals(oldValue))
                {
                    property.SetValue(existingAnime, newValue);
                    isUpdated = true;
                }
            }

            return isUpdated;
        }

        private async Task<ICollection<T>> FetchAndAssociateEntities<T>(ICollection<T> entitiesFromRequest, Func<T, object> keySelector, string keyType) where T : class, new()
        {
            var entitiesToInclude = new List<T>();
            foreach (var entity in entitiesFromRequest)
            {
                var key = keySelector(entity);
                var entityInDb = keyType == "Name"
                    ? await _dbContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == (string)key)
                    : await _dbContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<int>(e, "MalId") == (int)key);

                if (entityInDb != null)
                {
                    entitiesToInclude.Add(entityInDb);
                }
            }
            return entitiesToInclude;
        }


    }
}
