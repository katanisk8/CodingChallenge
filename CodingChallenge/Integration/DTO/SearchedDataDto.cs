namespace CodingChallenge.Integration.DTO
{
    public class SearchedDataDto
    {
        public string OneLineAddress { get; set; }
        public bool Geocode { get; set; }
        public string Organization { get; set; }
        public AddressDto Address { get; set; }
    }
}
