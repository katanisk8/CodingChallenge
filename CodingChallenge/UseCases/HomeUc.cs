using CodingChallenge.Integration.DTO;

namespace CodingChallenge.UseCases
{
    public interface IHomeUc
    {
        DataDto GetDefaultData();
    }

    public class HomeUc : IHomeUc
    {
        public DataDto GetDefaultData()
        {
            return new DataDto
            {
                Address = "Tokarskiego 4, Kraków 30-054",
                Country = "Polska"
            };
        }
    }
}
