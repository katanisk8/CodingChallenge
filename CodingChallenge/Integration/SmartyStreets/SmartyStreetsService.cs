using System.Linq;
using CodingChallenge.Integration.DTO;
using Microsoft.Extensions.Configuration;
using SmartyStreets;
using SmartyStreets.InternationalStreetApi;

namespace CodingChallenge.Integration.SmartyStreets
{
    public interface ISmartyStreetsService
    {
        InformationsDto GetInformations(SearchedDataDto dto);
    }

    public class SmartyStreetsService : ISmartyStreetsService
    {
        private readonly IConfiguration _configuration;

        public SmartyStreetsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public InformationsDto GetInformations(SearchedDataDto dto)
        {

            IConfigurationSection smartyAuthNSection = _configuration.GetSection("Integrations:SmartyStreets");
            var authId = smartyAuthNSection["Id"];
            var authToken = smartyAuthNSection["Token"];

            var client = new ClientBuilder(authId, authToken).BuildInternationalStreetApiClient();

            Lookup lookup = new Lookup(dto.Address, dto.Country);

            client.Send(lookup);

            var candidates = lookup.Result;
            var candidate = candidates.FirstOrDefault();

            return candidate != null
                ? GetInformationsDto(candidate.Components)
                : null;
        }

        public InformationsDto GetInformationsDto(Components components)
        {
            var informationsDto = new InformationsDto();

            foreach (var prop in typeof(Components).GetProperties())
            {
                var name = prop.Name;
                var value = prop.GetValue(components);

                if (!string.IsNullOrEmpty(name) && value != null)
                {
                    informationsDto.Informations.Add(name, value.ToString());
                }
            }

            return informationsDto;
        }
    }
}
