using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyGalla.Models
{
    public class ViewRequest
    {
        [Key]
        public string RequestId { get; set; }

        [Required]
        public string UserId { get; set; }  // FK → Users.UserId

        [Required]
        public string PropertyId { get; set; }  // FK → Properties.PropertyId

        public DateTime RequestedAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

    }
}
