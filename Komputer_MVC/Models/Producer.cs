namespace Komputer_MVC.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public required string Name { get; set; }
        public required string OriginCountry { get; set; }
        public required DateTime FoundationYear { get; set; }
        public required string Description { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; } 
        public required string Region { get; set; }
        public int ComputerId { get; set; }
    }
}
