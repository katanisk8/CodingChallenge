using System.Linq;
using CodingChallenge.Integration.DTO;
using Google.Maps;
using Google.Maps.Geocoding;
using Microsoft.Extensions.Configuration;

namespace CodingChallenge.Integration.GoogleMaps
{
    public interface IGoogleMapsService
    {
        LocationDto GetLocalization(SearchedDataDto dto);
    }

    public class GoogleMapsService : IGoogleMapsService
    {
        private readonly IConfiguration _configuration;
        public GoogleMapsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LocationDto GetLocalization(SearchedDataDto dto)
        {
            IConfigurationSection googleMapsSection = _configuration.GetSection("Integrations:Google");
            var apiKey = googleMapsSection["ApiKey"];

            GoogleSigned.AssignAllServices(new GoogleSigned(apiKey));

            var request = new GeocodingRequest
            {
                Address = PrepareAddress(dto)
            };
            var response = new GeocodingService().GetResponse(request);
            var result = response.Results.FirstOrDefault();

            if (result != null)
            {
                return new LocationDto
                {
                    Latitude = result.Geometry.Location.Latitude,
                    Longitude = result.Geometry.Location.Longitude
                };
            }

            return null;
        }

        private static Location PrepareAddress(SearchedDataDto dto)
        {
            if (!string.IsNullOrEmpty(dto.OneLineAddress))
            {
                return dto.OneLineAddress;
            }

            var address1 = dto.Address.Address1;
            var address2 = dto.Address.Address2;
            var locality = dto.Address.Locality;
            var administrativeArea = dto.Address.AdministrativeArea;
            var postalCode = dto.Address.PostalCode;

            return $"{address1} {address2}, {locality}, {administrativeArea} {postalCode}";
        }
    }
}
