using AutoMapper;
using CodingChallenge.Integration.SmartyStreets;
using CodingChallenge.Models;

namespace CodingChallenge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SmartyStreetViewModel, SmartyStreetsDto>();
        }
    }
}
