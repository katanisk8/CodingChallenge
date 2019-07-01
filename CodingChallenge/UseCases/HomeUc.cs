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
                Address = "Tokarskiego 4, Kraków 30-054",
                Country = "Polska"
            };
        }
    }
}
