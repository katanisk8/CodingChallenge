using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class IndexViewModel
    {
        [Display(Name = "Geo code")]
        public string Geocode { get; set; }
        [Display(Name = "Organization")]
        public string Organization { get; set; }
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        [Display(Name = "Locality")]
        public string Locality { get; set; }
        [Display(Name = "Administrative area")]
        public string AdministrativeArea { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
    }
}
