using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class AddressViewModel
    {
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string Locality { get; set; }

        [Display(Name = "Administrative area")]
        public string AdministrativeArea { get; set; }

        [Required]
        public string Country { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
    }
}
