using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassportWebApplication.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        
        
        [Required(ErrorMessage ="Please Enter the email address")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage ="Please enter the username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter the message here")]
        public string Description { get; set; }
        
        public FeedbackEnum Status { get; set; }

        
        [Required(ErrorMessage ="Select one options")]
        public FeedbackType FeedbackType { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
