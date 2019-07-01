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

            Lookup lookup = GetLookup(dto);

            client.Send(lookup);

            var candidates = lookup.Result;
            var candidate = candidates.FirstOrDefault();

            if (candidate == null)
            {
                return null;
            }

            return new InformationsDto
            {
                AdministrativeArea = candidate.Components.AdministrativeArea,
                CountryIso3 = candidate.Components.CountryIso3,
                Locality = candidate.Components.Locality,
                PostalCode = candidate.Components.PostalCode,
                PostalCodeShort = candidate.Components.PostalCodeShort,
                Premise = candidate.Components.Premise,
                PremiseNumber = candidate.Components.PremiseNumber,
                SubAdministrativeArea = candidate.Components.SubAdministrativeArea,
                Thoroughfare = candidate.Components.Thoroughfare
            };
        }

        private static Lookup GetLookup(SearchedDataDto dto)
        {
            if (CheckIfMoreDataIsFilled(dto))
            {
                return new Lookup
                {
                    Organization = dto.Organization,
                    Address1 = dto.Address.Address1,
                    Address2 = dto.Address.Address2,
                    Locality = dto.Address.Locality,
                    AdministrativeArea = dto.Address.AdministrativeArea,
                    Country = dto.Address.Country,
                    PostalCode = dto.Address.PostalCode
                };
            }

            return new Lookup(dto.OneLineAddress, dto.Address.Country);
        }

        private static bool CheckIfMoreDataIsFilled(SearchedDataDto dto)
        {
            return !string.IsNullOrEmpty(dto.Organization) ||
                   !string.IsNullOrEmpty(dto.Address.Address1) ||
                   !string.IsNullOrEmpty(dto.Address.Address2) ||
                   !string.IsNullOrEmpty(dto.Address.Locality) ||
                   !string.IsNullOrEmpty(dto.Address.AdministrativeArea) ||
                   !string.IsNullOrEmpty(dto.Address.PostalCode);
        }
    }
}
