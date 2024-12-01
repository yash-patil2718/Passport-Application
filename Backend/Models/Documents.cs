using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.Models
{
    public class Documents
    {
        [Key]
        public int DocumentsId { get; set; }

       /* //[Required(ErrorMessage ="Please upload the Aadharcard.")]
        public byte[]? AadharCard { get; set; }

        //[Required(ErrorMessage ="Please upload the passport size photo.")]
        public byte[]? Photo { get; set; }

        //[Required(ErrorMessage ="Please upload the signature Image.")]
        public byte[]? Signature { get; set; }

        public byte[]? Pancard { get; set; }*/

        [Required(ErrorMessage ="Please accept the terms and condition")]
        public bool IsAcceptTermsAndCondition { get; set; }

        [Required(ErrorMessage ="Please enter the palce.")]
        public string Place { get; set; }

        [Required(ErrorMessage ="Please enter the date.")]
        [DataType(DataType.Date)]
        public DateTime DateOfAppApplied { get; set; }

    }
}
