using AutoMapper;
using CodingChallenge.Integration.DTO;
using CodingChallenge.Models;

namespace CodingChallenge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressViewModel, AddressDto>();
            CreateMap<AddressDto, AddressViewModel>();

            CreateMap<SearchedDataVieModel, SearchedDataDto>();
            CreateMap<SearchedDataDto, SearchedDataVieModel>();

            CreateMap<LocationViewModel, LocationDto>();
            CreateMap<LocationDto, LocationViewModel>();

            CreateMap<SearchedResultViewModel, SearchedResultDto>();
            CreateMap<SearchedResultDto, SearchedResultViewModel>();
        }
    }
}
