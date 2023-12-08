using AnimeList.DTO;

namespace AnimeList.Interfaces
{
    public interface IAnimeService
    {
        Task<GenericResponse<AnimeResponse>> SearchAnimeById(string animeId);
        Task<GenericResponse<AnimeResponse>> GetAllAnimesByQuery(string query);
    }
}
