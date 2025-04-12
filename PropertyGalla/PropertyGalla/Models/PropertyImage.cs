using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyGalla.Models
{
    public class PropertyImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string PropertyId { get; set; }  // FK → Properties.PropertyId

        [Required]
        public string ImageUrl { get; set; }

        // ✅ Add this navigation property
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
