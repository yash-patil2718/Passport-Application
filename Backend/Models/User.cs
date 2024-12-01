
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassportWebApplication.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        
        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should have length between 3 to 50.")]
        [Required(ErrorMessage ="Firstname Required")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should have length between 3 to 50.")]
        [Required(ErrorMessage = "MiddleName Required")]
        public string MiddleName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should have length between 3 to 50.")]
        [Required(ErrorMessage = "Lastname Required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Please enter the email address.")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage ="Please Enter the password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
            ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter the mobile number")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Enter 10 digit number")]
        [Phone]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage ="Plese enter the Username")]   
        public string UserName { get; set; }

        [ForeignKey("PassportUser")]
        public string PassportUserId { get; set; }
        public PassportUser PassportUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }

        public ICollection<MasterDetails> Applications { get; set; }   
        public ICollection<Feedback> Feedbacks { get; set; }


    }
}
