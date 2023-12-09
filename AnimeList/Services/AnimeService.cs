using AnimeList.Models.AnimeModel;
using Newtonsoft.Json;


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

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AnimeModel>(content);
        }
    }
}
