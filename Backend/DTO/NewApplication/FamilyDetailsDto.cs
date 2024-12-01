using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.NewApplication
{
    public class FamilyDetailsDto
    {

        [Required(ErrorMessage = "Please enter the father name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name characters should have length between 3 to 50")]
        public string FatherFirstName { get; set; }


        [Required(ErrorMessage = "Please enter the father Surnamename")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name characters should have length between 3 to 50")]
        public string FatherSurname { get; set; }


        [Required(ErrorMessage = "Please enter the mother first name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name characters should have length between 3 to 50")]
        public string MotherFirstName { get; set; }


        [Required(ErrorMessage = "Please enter the mother Surnamename")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name characters should have length between 3 to 50")]
        public string MotherSurname { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name characters should have length between 3 to 50")]
        public string? LeagalGuardianFirstName { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name characters should have length between 3 to 50")]
        public string? LeagalGuardianSurname { get; set; }


        [StringLength(50, ErrorMessage = "Name characters length should be less than 50")]
        public string? SpouceFirstName { get; set; }

        [StringLength(50, ErrorMessage = "Name characters length should be less than 50")]
        public string? SpouceSurname { get; set; }
    }
}
