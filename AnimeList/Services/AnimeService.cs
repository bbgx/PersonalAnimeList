using AnimeICollection.Models.AnimeModel;
using AnimeList.Data;
using AnimeList.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection;
using System.Text.Json;

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
            var existingAnime = await _dbContext.Animes
                .Include(p => p.MediaProducers)
                .Include(p => p.MediaLicensors)
                .Include(p => p.MediaStudios)
                .Include(p => p.MediaGenres)
                .Include(p => p.MediaThemes)
                .Include(p => p.MediaDemographics)
                .Include(p => p.StreamingWebsites)
                .FirstOrDefaultAsync(anime => anime.MalId == animeId);

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

                existingAnime.MediaProducers = (List<AnimeModel.Producer>?)await FetchAndAssociateEntities(newAnimeData.MediaProducers, x => x.Name, "Name");
                existingAnime.MediaStudios = (List<AnimeModel.Studio>?)await FetchAndAssociateEntities(newAnimeData.MediaStudios, x => x.MalId, "MalId");
                existingAnime.MediaLicensors = (List<AnimeModel.Licensor>?)await FetchAndAssociateEntities(newAnimeData.MediaLicensors, x => x.MalId, "MalId");
                existingAnime.MediaGenres = (List<AnimeModel.Genre>?)await FetchAndAssociateEntities(newAnimeData.MediaGenres, x => x.MalId, "MalId");
                existingAnime.MediaThemes = (List<AnimeModel.Theme>?)await FetchAndAssociateEntities(newAnimeData.MediaThemes, x => x.MalId, "MalId");
                existingAnime.MediaDemographics = (List<AnimeModel.Demographic>?)await FetchAndAssociateEntities(newAnimeData.MediaDemographics, x => x.MalId, "MalId");
                existingAnime.StreamingWebsites = (List<AnimeModel.Streaming>?)await FetchAndAssociateEntities(newAnimeData.StreamingWebsites, x => x.Name, "Name");

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

        public async Task<AnimeSearchModel> GetAnimeWithParametersAsync(AnimeQueryParameters parameters)
        {
            var queryString = parameters.ToQueryString();
            var url = $"https://api.jikan.moe/v4/anime?{queryString}";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            options.Converters.Add(new AnimeSearchModelConverter(_mapper));
            var animeResponse = JsonSerializer.Deserialize<AnimeSearchModel>(content, options);
            
            return animeResponse;

        }

        public class AnimeQueryParameters
        {
            public int? Page { get; set; }
            public int? Limit { get; set; }
            public string? Q { get; set; }
            public string? Type { get; set; }
            public string? Status { get; set; }
            public List<string> Genres { get; set; } = new List<string>();
            public string? OrderBy { get; set; }
            public string? Sort { get; set; }
            public string? Letter { get; set; }
            public List<int> Producers { get; set; } = new List<int>();

            public string ToQueryString()
            {
                var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
                if (Page.HasValue)
                    query["page"] = Page.Value.ToString();
                if (Limit.HasValue)
                    query["limit"] = Limit.Value.ToString();
                if (!string.IsNullOrEmpty(Q))
                    query["q"] = Q;
                if (!string.IsNullOrEmpty(Type))
                    query["type"] = Type;
                if (!string.IsNullOrEmpty(Status))
                    query["status"] = Status;
                if (Genres != null && Genres.Any())
                    query["genres"] = string.Join(",", Genres);
                if (!string.IsNullOrEmpty(OrderBy))
                    query["order_by"] = OrderBy;
                if (!string.IsNullOrEmpty(Sort))
                    query["sort"] = Sort;
                if (!string.IsNullOrEmpty(Letter))
                    query["letter"] = Letter;
                if (Producers != null && Producers.Any())
                    query["producers"] = string.Join(",", Producers);

                return query.ToString();
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
