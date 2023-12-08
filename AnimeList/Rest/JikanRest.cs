using AnimeList.DTO;
using AnimeList.Interfaces;
using AnimeList.Models.AnimeModel;
using System.Dynamic;
using System.Text.Json;

namespace AnimeList.Rest
{
    public class JikanRest : IJikanService
    {
        public Task<GenericResponse<AnimeModel>> GetAllAnimesByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<AnimeModel>> SearchAnimeById(string animeId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.jikan.moe/v4/anime/{animeId}/full");

            var response = new GenericResponse<AnimeModel>();
            using (var client = new HttpClient())
            {
                var responseJinkan = await client.SendAsync(request);
                var contentResponse = await responseJinkan.Content.ReadAsStringAsync();
                Console.WriteLine(contentResponse);
                var objResponse = JsonSerializer.Deserialize<AnimeModel>(contentResponse);

                if (responseJinkan.IsSuccessStatusCode)
                {
                    response.HttpCode = responseJinkan.StatusCode;
                    response.ReturnData = objResponse;
                } else
                {
                    response.HttpCode = responseJinkan.StatusCode;
                    response.ReturnError = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }

            return response;
        }
    }
}
