using AnimeList.DTO;
using AnimeList.Models.AnimeModel;
using AutoMapper;

namespace AnimeList.Mappings
{
    public class AnimeMapping : Profile
    {
        public AnimeMapping()
        {
            CreateMap(typeof(GenericResponse<>), typeof(GenericResponse<>));
            CreateMap<AnimeResponse, AnimeModel>();
            CreateMap<AnimeModel, AnimeResponse>();
        }
    }
}
