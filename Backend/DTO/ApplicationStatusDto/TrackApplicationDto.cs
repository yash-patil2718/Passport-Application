using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.ApplicationStatusDto
{
    public class TrackApplicationDto
    {
        [Required]
        public ApplicationType ApplicationType { get; set; }

        [Required]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Application no must be 10 digit long.")]
        public string ApplicationNo { get; set; }

        [DataType(DataType.Date,ErrorMessage ="Please Enter the Date of birth.")]
        public DateTime DOB {  get; set; } 
    }
}
