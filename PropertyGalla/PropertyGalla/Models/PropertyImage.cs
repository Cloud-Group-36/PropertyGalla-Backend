using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        // ✅ Prevent JSON infinite loop
        [JsonIgnore]
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
