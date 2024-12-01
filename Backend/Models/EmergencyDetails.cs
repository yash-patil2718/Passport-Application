using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.Models
{
    public class EmergencyDetails
    {
        [Key]
        public int EmergencyDetailsId { get; set; }


        [Required(ErrorMessage ="Please Enter the contact name.")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Contact Name should have length between 3 to 50.")]
        public string EmergencyContactName { get; set; }


        [Required(ErrorMessage = "Please Enter the contact address.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Contact address should have length between 3 to 100.")]
        public string EmergencyContactAddress { get; set; }



        [Required(ErrorMessage = "Please Enter the contact mobile no.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact mobile should have length between 3 to 10.")]
        public string EmergencyContactMobileNo { get; set; }



        [Required(ErrorMessage = "Please Enter the contact email address.")]
        [EmailAddress]
        public string EmergencyContactEmail { get; set; }

        
        
        [Required(ErrorMessage = "Please Enter the city.")]
        public string EmergencyContactCity { get; set; }


        [Required(ErrorMessage = "Please Enter the pincode.")]
        [StringLength(6, MinimumLength =6 ,ErrorMessage ="Pincode should be digit no 6")]
        public string Pincode { get; set; }
        

        [Required(ErrorMessage ="Please enter the district name.")]
        public string District { get; set; }


        [Required(ErrorMessage = "Please select one option.")]
        public State State { get; set; }

    }
}
