using AutoMapper;
using CodingChallenge.Integration.DTO;
using CodingChallenge.Models;

namespace CodingChallenge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataVieModel, DataDto>();
            CreateMap<DataDto, DataVieModel>();

            CreateMap<InformationsViewModel, InformationsDto>();
            CreateMap<InformationsDto, InformationsViewModel>();

            CreateMap<LocationViewModel, LocationDto>();
            CreateMap<LocationDto, LocationViewModel>();

            CreateMap<ResultViewModel, ResultDto>();
            CreateMap<ResultDto, ResultViewModel>();
        }
    }
}
