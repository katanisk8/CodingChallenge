using AutoMapper;
using CodingChallenge.Integration.DTO;
using CodingChallenge.Models;

namespace CodingChallenge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchedDataVieModel, SearchedDataDto>();
            CreateMap<SearchedDataDto, SearchedDataVieModel>();

            CreateMap<InformationsViewModel, InformationsDto>();
            CreateMap<InformationsDto, InformationsViewModel>();

            CreateMap<LocationViewModel, LocationDto>();
            CreateMap<LocationDto, LocationViewModel>();

            CreateMap<SearchedResultViewModel, SearchedResultDto>();
            CreateMap<SearchedResultDto, SearchedResultViewModel>();
        }
    }
}
