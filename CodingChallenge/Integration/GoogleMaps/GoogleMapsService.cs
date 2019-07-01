using System.Linq;
using CodingChallenge.Integration.DTO;
using Google.Maps;
using Google.Maps.Geocoding;
using Microsoft.Extensions.Configuration;

namespace CodingChallenge.Integration.GoogleMaps
{
    public interface IGoogleMapsService
    {
        LocationDto GetLocalization(DataDto dto);
    }

    public class GoogleMapsService : IGoogleMapsService
    {
        private readonly IConfiguration _configuration;

        public GoogleMapsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LocationDto GetLocalization(DataDto dto)
        {
            IConfigurationSection googleMapsSection = _configuration.GetSection("Integrations:Google");
            var apiKey = googleMapsSection["ApiKey"];

            GoogleSigned.AssignAllServices(new GoogleSigned(apiKey));

            var request = new GeocodingRequest
            {
                Address = dto.Address
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
    }
}
