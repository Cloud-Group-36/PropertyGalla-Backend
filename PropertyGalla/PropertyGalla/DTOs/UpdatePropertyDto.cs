namespace PropertyGalla.DTOs
{
    public class UpdatePropertyDto
    {
        public string PropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string OwnerId { get; set; }
        public List<string> Images { get; set; } // only URLs
    }

}
