using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class SearchedDataVieModel
    {
        [Display(Name = "Full address")]
        public string OneLineAddress { get; set; }

        public bool Geocode { get; set; }

        public string Organization { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
