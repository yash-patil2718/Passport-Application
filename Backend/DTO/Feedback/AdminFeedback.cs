using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.Feedback
{
    public class AdminFeedbackDto
    {

        public int FeedbackId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }

        public FeedbackEnum Status { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
