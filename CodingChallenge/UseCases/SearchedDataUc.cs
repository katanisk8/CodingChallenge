using CodingChallenge.Integration.DTO;
using CodingChallenge.Integration.GoogleMaps;
using CodingChallenge.Integration.SmartyStreets;

namespace CodingChallenge.UseCases
{
    public interface ISearchedDataUc
    {
        SearchedResultDto GetMoreInformations(SearchedDataDto dto);
    }

    public class SearchedDataUc : ISearchedDataUc
    {
        private readonly ISmartyStreetsService _smartyStreetsService;
        private readonly IGoogleMapsService _googleMapsService;

        public SearchedDataUc(
            ISmartyStreetsService smartyStreetsService,
            IGoogleMapsService googleMapsService)
        {
            _smartyStreetsService = smartyStreetsService;
            _googleMapsService = googleMapsService;
        }

        public SearchedResultDto GetMoreInformations(SearchedDataDto dto)
        {
            var informations = _smartyStreetsService.GetInformations(dto);
            var location = _googleMapsService.GetLocalization(dto);

            return new SearchedResultDto
            {
                Informations = informations,
                Location = location
            };
        }
    }
}
