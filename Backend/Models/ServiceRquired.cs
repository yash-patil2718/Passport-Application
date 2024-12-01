using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.Models
{
    public class ServiceRquired
    {
        [Key]
        public int ServiceRequiredId { get; set; }
        
        
        [Required(ErrorMessage ="Please select one option")]
        public ApplicationType ApplicationType { get; set; }


        [Required(ErrorMessage = "Please select one option")]
        public PagesRequried PagesRequried { get; set; }

        
        [Required(ErrorMessage = "Please select one option")]
        public ValidityRequired ValidityRequired { get; set; }


        public ReasonforRenewal ReasonforRenewal { get; set; }

        public ChangeInAppearance ChangeInAppearance { get; set; }
    }
}
