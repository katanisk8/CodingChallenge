namespace CodingChallenge.Integration.SmartyStreets
{
    public class SmartyStreetsDto
    {
        public bool Geocode { get; set; }
        public string Organization { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Locality { get; set; }
        public string AdministrativeArea { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
