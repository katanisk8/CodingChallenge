using CodingChallenge.Integration.DTO;
using CodingChallenge.Integration.GoogleMaps;
using CodingChallenge.Integration.SmartyStreets;

namespace CodingChallenge.UseCases
{
    public interface IDataUc
    {
        ResultDto GetMoreInformations(DataDto dto);
    }

    public class DataUc : IDataUc
    {
        private readonly ISmartyStreetsService _smartyStreetsService;
        private readonly IGoogleMapsService _googleMapsService;

        public DataUc(
            ISmartyStreetsService smartyStreetsService,
            IGoogleMapsService googleMapsService)
        {
            _smartyStreetsService = smartyStreetsService;
            _googleMapsService = googleMapsService;
        }

        public ResultDto GetMoreInformations(DataDto dto)
        {
            var informations = _smartyStreetsService.GetInformations(dto);
            var location = _googleMapsService.GetLocalization(dto);

            return new ResultDto
            {
                Informations = informations,
                Location = location
            };
        }
    }
}
