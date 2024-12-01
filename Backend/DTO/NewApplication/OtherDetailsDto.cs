using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.NewApplication
{
    public class OtherDetailsDto
    {

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsCriminalProceedings { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsWarrantSummons { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IArrestWarrant { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsDepartureOrder { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IConviction { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsPassportRefusal { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsPassportImpounded { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IspassportRevoked { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsForeignCitizenship { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsotherPassport { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsSurrenderedPassport { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsRenunciation { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsEmergencyCertificate { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsDeported { get; set; }

        [Required(ErrorMessage = "Please choose one option.")]
        public bool IsRepatriated { get; set; }
    }
}
