using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.NewApplication
{
    public class ApplicantDetailsDto
    {

        [Required(ErrorMessage = "Please enter the Applicant first name")]
        [StringLength(50, ErrorMessage = "name characters length should be between 3 to 50")]
        public string ApplicantFirstName { get; set; }


        [Required(ErrorMessage = "Please enter the Applicant surname")]
        [StringLength(50, ErrorMessage = "Name characters length should be between 3 to 50")]
        public string ApplicantLastName { get; set; }

        [Required(ErrorMessage = "Please choose option.")]
        public bool IsAliases { get; set; }

        [StringLength(50, ErrorMessage = "Name characters length should be less than 50")]
        public string? AliasName { get; set; }

        [Required(ErrorMessage = "Please choose option.")]
        public bool IsChangedName { get; set; }

        [StringLength(50, ErrorMessage = "Name characters length should be less than 50")]
        public string? PreviousName { get; set; }

        [Required(ErrorMessage = "Please enter the Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Please enter the place of birth.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Place of birth characters length should be between 3 to 50")]
        public string PlaceOfBirth { get; set; }

        [Required(ErrorMessage = "Please choose the option.")]
        public Gender Gender { get; set; }      // enum 

        [Required(ErrorMessage = "Please enter the District name.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Please choose the option.")]
        public State State { get; set; }     // enum

        [Required(ErrorMessage = "Please choose the option.")]
        public Country Country { get; set; }   // enum


        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter valid pancard no.")]
        public string PancardNo { get; set; }


        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter valid pancard no.")]
        public string VoterIdNo { get; set; }

        [Required(ErrorMessage = "Please Enter the aadhar card number")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Please enter the valid number.")]
        public string AadharcardNo { get; set; }


        [Required(ErrorMessage = "Please choose the option.")]
        public MaritalStatus MaritalStatus { get; set; }    //enum 


        [Required(ErrorMessage = "Please choose the option.")]
        public EmployeementType EmployementType { get; set; } //  enum


        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please Enter the organizatiion name.")]
        public string? OrganizationName { get; set; }


        [Required(ErrorMessage = "Please select the option.")]
        public bool IsParentOrSpouceGovermentServent { get; set; }


        [Required(ErrorMessage = "Please choose the option.")]
        public EducationalQualification EducationQualification { get; set; }  //  enum


        [Required(ErrorMessage = "Please choose the option.")]
        public Citizenship Citizenship { get; set; }    //enum 


        [Required(ErrorMessage = "Please choose the option.")]
        public bool IsNonEcrEligible { get; set; }


        [Required(ErrorMessage = "Please enter the Distinguish mark")]
        public string DistinguishMark { get; set; }

        public string? PreviousPassportNumber { get; set; }


        public DateTime? DateOfIssue { get; set; }

        public string? PlaceOfIssue { get; set; }

    }
}
