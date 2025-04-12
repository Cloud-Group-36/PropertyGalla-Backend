namespace PropertyGalla.DTOs.ProprtyDTOs
{
    public class GetPropertyDto
    {
        public string PropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string OwnerId { get; set; }
        public string Status { get; set; }
        public List<string> Images { get; set; }
    }
}
