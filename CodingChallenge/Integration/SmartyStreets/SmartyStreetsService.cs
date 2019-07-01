using CodingChallenge.Integration.DTO;
using Microsoft.Extensions.Configuration;
using SmartyStreets;
using SmartyStreets.InternationalStreetApi;

namespace CodingChallenge.Integration.SmartyStreets
{
    public interface ISmartyStreetsService
    {
        void GetInformations(SearchedDataDto dto);
    }

    public class SmartyStreetsService : ISmartyStreetsService
    {
        private readonly IConfiguration _configuration;

        public SmartyStreetsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void GetInformations(SearchedDataDto dto)
        {

            IConfigurationSection smartyAuthNSection = _configuration.GetSection("Integrations:SmartyStreets");
            var authId = smartyAuthNSection["Id"];
            var authToken = smartyAuthNSection["Token"];

            var client = new ClientBuilder(authId, authToken).BuildInternationalStreetApiClient();

            Lookup lookup = GetLookup(dto);

            //Exception: Payment Required: There is no active subscription for the account associated with the credentials submitted with the request.
            //250 lookups free
            //Why?
            //client.Send(lookup);

            //var candidates = lookup.Result;
            //var firstCandidate = candidates[0];
        }

        private static Lookup GetLookup(SearchedDataDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.OneLineAddress))
            {
                return new Lookup(dto.OneLineAddress, dto.Address.Country);
            }

            return new Lookup
            {
                Geocode = dto.Geocode,
                Organization = dto.Organization,
                Address1 = dto.Address.Address1,
                Address2 = dto.Address.Address2,
                Locality = dto.Address.Locality,
                AdministrativeArea = dto.Address.AdministrativeArea,
                Country = dto.Address.Country,
                PostalCode = dto.Address.PostalCode
            };
        }
    }
}
