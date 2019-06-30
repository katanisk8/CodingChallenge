using CodingChallenge.Integration;
using CodingChallenge.Integration.SmartyStreets;

namespace CodingChallenge.UseCases
{
    public interface ISmartyStreetUc
    {
        void GetInformation(SmartyStreetsDto dto);
    }

    public class SmartyStreetUc : ISmartyStreetUc
    {
        private readonly ISmartyStreetsService _smartyStreetsService;

        public SmartyStreetUc(ISmartyStreetsService smartyStreetsService)
        {
            _smartyStreetsService = smartyStreetsService;
        }

        public void GetInformation(SmartyStreetsDto dto)
        {
            _smartyStreetsService.Get(dto);
        }
    }
}
