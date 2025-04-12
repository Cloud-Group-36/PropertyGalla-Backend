using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyGalla.Models
{
    public class ContactMessage
    {
        [Key]
        public string MessageId { get; set; }

        [Required]
        public string SenderId { get; set; }  // FK → Users.UserId

        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }  // FK → Users.UserId

        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

        [Required]
        public string PropertyId { get; set; }  // FK → Properties.PropertyId

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
