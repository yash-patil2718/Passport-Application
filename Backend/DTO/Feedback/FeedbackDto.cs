using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.Feedback
{
    public class FeedbackDto
    {

        [Required(ErrorMessage = "Please Enter the email address")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter the username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter the message here")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Select one options")]
        public FeedbackType FeedbackType { get; set; }

        public DateTime ?CreatedOn { get; set; }

        public DateTime ?UpdatedOn { get; set; }

    }
}
