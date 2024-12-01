using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please enter the Username.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "please enter the Passwords.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
    