using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class SearchedDataVieModel
    {
        [Display(Name = "Full address")]
        public string OneLineAddress { get; set; }

        public string Country { get; set; }
    }
}
