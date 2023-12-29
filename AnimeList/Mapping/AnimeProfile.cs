using AnimeICollection.Models.AnimeModel;
using AnimeList.DTO;
using AnimeList.Models;
using AutoMapper;

namespace AnimeList.Mapping
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile() 
        {

            try
            {
                CreateMap<AnimeModel, BaseAnimeModelDTO>();
                CreateMap<BaseAnimeModel, BaseAnimeModel>()
                    .ForMember(dest => dest.MediaProducers, opt => opt.Ignore())
                    .ForMember(dest => dest.MediaLicensors, opt => opt.Ignore())
                    .ForMember(dest => dest.MediaStudios, opt => opt.Ignore())
                    .ForMember(dest => dest.MediaGenres, opt => opt.Ignore())
                    .ForMember(dest => dest.MediaThemes, opt => opt.Ignore())
                    .ForMember(dest => dest.MediaDemographics, opt => opt.Ignore())
                    .ForMember(dest => dest.StreamingWebsites, opt => opt.Ignore());
                CreateMap<AnimeSearchModel, BaseAnimeModelDTO>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
                CreateMap<Models.BaseAnimeModel.Producer, ProducerDTO>();
                CreateMap<Models.BaseAnimeModel.Licensor, LicensorDTO>();
                CreateMap<Models.BaseAnimeModel.Studio, StudioDTO>();
                CreateMap<Models.BaseAnimeModel.Genre, GenreDTO>();
                CreateMap<Models.BaseAnimeModel.Theme, ThemeDTO>();
                CreateMap<Models.BaseAnimeModel.Demographic, DemographicDTO>();
                CreateMap<Models.BaseAnimeModel.Streaming, StreamingDTO>();
            }
            catch (AutoMapperMappingException ex)
            {
                // Log details of the exception
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                // Consider logging the problematic object or other context if possible
            }
        }
    }
}
