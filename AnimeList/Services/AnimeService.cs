using AnimeList.DTO;
using AnimeList.Interfaces;
using AnimeList.Models.AnimeModel;
using AutoMapper;
using Newtonsoft.Json;

namespace AnimeList.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IMapper _mapper;
        private readonly IJikanService _jikanService;

        public AnimeService(IMapper mapper, IJikanService jikanService)
        {
            _mapper = mapper;
            _jikanService = jikanService;
        }

        public Task<GenericResponse<AnimeResponse>> GetAllAnimesByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<AnimeResponse>> SearchAnimeById(string animeId)
        {
            var anime = await _jikanService.SearchAnimeById(animeId);
            return _mapper.Map<GenericResponse<AnimeResponse>>(anime);
        }
    }
}
