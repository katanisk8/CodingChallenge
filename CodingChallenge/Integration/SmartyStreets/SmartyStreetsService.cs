using CodingChallenge.Integration.SmartyStreets;
using Microsoft.Extensions.Configuration;
using SmartyStreets;
using SmartyStreets.InternationalStreetApi;

namespace CodingChallenge.Integration
{
    public interface ISmartyStreetsService
    {
        void Get(SmartyStreetsDto dto);
    }

    public class SmartyStreetsService : ISmartyStreetsService
    {
        private readonly IConfiguration _configuration;

        public SmartyStreetsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Get(SmartyStreetsDto dto)
        {

            IConfigurationSection smartyAuthNSection = _configuration.GetSection("Integrations:SmartyStreets");
            var authId = smartyAuthNSection["Id"];
            var authToken = smartyAuthNSection["Token"];

            var client = new ClientBuilder(authId, authToken).BuildInternationalStreetApiClient();
            
            var lookup = new Lookup()
            {
                InputId = "ID-8675309",
                Geocode = dto.Geocode,
                Organization = dto.Organization,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Locality = dto.Locality,
                AdministrativeArea = dto.AdministrativeArea,
                Country = dto.Country,
                PostalCode = dto.PostalCode
            };

            //Exception: Payment Required: There is no active subscription for the account associated with the credentials submitted with the request.
            //250 lookups free
            //Why?
            client.Send(lookup);

            var candidates = lookup.Result;
            var firstCandidate = candidates[0];
        }
    }
}
