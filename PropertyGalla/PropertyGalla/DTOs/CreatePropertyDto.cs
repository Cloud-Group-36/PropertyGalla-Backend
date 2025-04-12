namespace PropertyGalla.Models
{
    public class CreatePropertyDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string OwnerId { get; set; }
        public List<string> Images { get; set; }
    }
}
