using AnimeICollection.Models.AnimeModel;
using AutoMapper;

namespace AnimeList.Mapping
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile() 
        {
            CreateMap<AnimeModel, AnimeModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MediaProducers, opt => opt.Ignore())
                .ForMember(dest => dest.MediaLicensors, opt => opt.Ignore())
                .ForMember(dest => dest.MediaStudios, opt => opt.Ignore())
                .ForMember(dest => dest.MediaGenres, opt => opt.Ignore())
                .ForMember(dest => dest.MediaThemes, opt => opt.Ignore())
                .ForMember(dest => dest.MediaDemographics, opt => opt.Ignore())
                .ForMember(dest => dest.StreamingWebsites, opt => opt.Ignore());
        }
    }
}
