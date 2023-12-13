using AnimeICollection.Models.AnimeModel;
using AnimeList.Models;
using System.Text.Json;


namespace AnimeList.Services
{
    public class AnimeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AnimeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AnimeModel> GetAnimeByIdAsync (int animeId)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"https://api.jikan.moe/v4/anime/{animeId}/full");

            response.EnsureSuccessStatusCode();
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnimeModelConverter());
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AnimeModel>(content, options);
        }
    }
}
