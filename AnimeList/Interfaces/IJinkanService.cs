using AnimeList.DTO;
using AnimeList.Models.AnimeModel;

namespace AnimeList.Interfaces
{
    public interface IJikanService
    {
        Task<GenericResponse<AnimeModel>> SearchAnimeById(string animeId);
        Task<GenericResponse<AnimeModel>> GetAllAnimesByQuery(string query);
    }
}
