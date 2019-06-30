using Microsoft.Extensions.Configuration;
using SmartyStreets;
using SmartyStreets.InternationalStreetApi;

namespace CodingChallenge.Integration
{
    public class SmartyStreetsService
    {
        private readonly IConfiguration _configuration;

        public SmartyStreetsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void RunItegration()
        {
            IConfigurationSection smartyAuthNSection = _configuration.GetSection("Integrations:SmartyStreets");
            var authId = smartyAuthNSection["Id"];
            var authToken = smartyAuthNSection["Token"];

            var client = new ClientBuilder(authId, authToken).BuildInternationalStreetApiClient();

            var lookup = new Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil")
            {
                InputId = "ID-8675309",
                Geocode = true,
                Organization = "John Doe",
                Address1 = "Rua Padre Antonio D'Angelo 121",
                Address2 = "Casa Verde",
                Locality = "Sao Paulo",
                AdministrativeArea = "SP",
                Country = "Brazil",
                PostalCode = "02516-050"
            };

            client.Send(lookup);

            var candidates = lookup.Result;
            var firstCandidate = candidates[0];
        }
    }
}
