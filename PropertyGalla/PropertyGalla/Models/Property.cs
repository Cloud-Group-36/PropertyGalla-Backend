using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyGalla.Models
{
    public class Property
    {
        [Key]
        public string PropertyId { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }  
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string Status { get; set; } = "available";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<PropertyImage> Images { get; set; }


    }
}
