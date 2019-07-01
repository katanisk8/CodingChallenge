using CodingChallenge.Integration;
using CodingChallenge.Integration.DTO;

namespace CodingChallenge.UseCases
{
    public interface IHomeUc
    {
        SearchedDataDto GetDefaultSearchedData();
    }

    public class HomeUc : IHomeUc
    {
        public SearchedDataDto GetDefaultSearchedData()
        {
            return new SearchedDataDto
            {
                OneLineAddress = "Tokarskiego 4 Kraków 30-054, Polska",
                Geocode = true,
                Organization = "Michal Makowej",
                Address = new AddressDto
                {
                    Address1 = "Tokarkiego 4",
                    Address2 = "",
                    Locality = "Krakow",
                    AdministrativeArea = "Pl",
                    Country = "Polska",
                    PostalCode = "30-065"
                }
            };
        }
    }
}
