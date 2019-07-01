using CodingChallenge.Integration;
using CodingChallenge.Integration.SmartyStreets;

namespace CodingChallenge.UseCases
{
    public interface ISmartyStreetUc
    {
        SmartyStreetsDto GetSmartyStreetsDto();
        void GetInformation(SmartyStreetsDto dto);
    }

    public class SmartyStreetUc : ISmartyStreetUc
    {
        private readonly ISmartyStreetsService _smartyStreetsService;

        public SmartyStreetUc(ISmartyStreetsService smartyStreetsService)
        {
            _smartyStreetsService = smartyStreetsService;
        }

        public SmartyStreetsDto GetSmartyStreetsDto()
        {
            return GetDeafultSmartyStreetsDto();
        }

        public void GetInformation(SmartyStreetsDto dto)
        {
            _smartyStreetsService.Get(dto);
        }

        private SmartyStreetsDto GetDeafultSmartyStreetsDto()
        {
            return new SmartyStreetsDto
            {
                Geocode = true,
                Organization = "John Doe",
                Address1 = "Rua Padre Antonio D'Angelo 121",
                Address2 = "Casa Verde",
                Locality = "Sao Paulo",
                AdministrativeArea = "SP",
                Country = "Brazil",
                PostalCode = "02516-050"
            };
        }
    }
}
