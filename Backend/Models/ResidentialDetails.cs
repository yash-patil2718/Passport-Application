using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.Models
{
    public class ResidentialDetails
    {
        [Key]
        public int ResidentialDetailsId { get; set; }


        [Required(ErrorMessage = "Please enter the house details.")]
        public string HouseNoAndName { get; set; }

        [Required(ErrorMessage = "Please enter the details of lane 1.")]
        public string AddressLane1 { get; set; }

        public string AddressLane2 { get; set; }

        
        [Required(ErrorMessage ="Please enter the Village or city.")]
        public string VillageOrCityName { get; set; }

        
        [Required(ErrorMessage = "Please Select one option.")]
        public string District { get; set; }

        
        [Required(ErrorMessage ="Please Select one option.")]
        public State State { get; set; }

        
        [Required(ErrorMessage = "Please Select one option.")]
        public Country Country { get; set; }


        [Required(ErrorMessage = "Please enter the pincode.")]
        [StringLength(6,MinimumLength =6,ErrorMessage ="Pincode should be 6 digit no.")]
        public string Pincode { get; set; }


        [Required(ErrorMessage = "Please enter the mobile no.")]
        [StringLength(10,MinimumLength =10, ErrorMessage ="Please enter 10 digit mobile no.")]
        public string MobileNo { get; set; }


        [StringLength(10, ErrorMessage = "Please enter 10 digit mobile no.")]
        public string TelephoneNo { get; set; }

    }
}
