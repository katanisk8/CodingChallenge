using System.Collections.Generic;

namespace CodingChallenge.Integration.DTO
{
    public class InformationsDto
    {
        public InformationsDto()
        {
            Informations = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Informations { get; set; }
    }
}
