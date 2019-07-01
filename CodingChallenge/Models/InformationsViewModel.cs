using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class InformationsViewModel
    {
        [Display(Name = "Administrative area")]
        public string AdministrativeArea { get; set; }

        [Display(Name = "Country code ISO-3")]
        public string CountryIso3 { get; set; }

        public string Locality { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "Short postal code")]
        public string PostalCodeShort { get; set; }

        public string Premise { get; set; }
        
        [Display(Name = "Premise number")]
        public string PremiseNumber { get; set; }

        [Display(Name = "Sub administrative area")]
        public string SubAdministrativeArea { get; set; }

        public string Thoroughfare { get; set; }
    }
}
