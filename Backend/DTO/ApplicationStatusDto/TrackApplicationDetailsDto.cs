using PassportWebApplication.Enums;

namespace PassportWebApplication.DTO.ApplicationStatusDto
{
    public class TrackApplicationDetailsDto
    {
        public string ApplicantName { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public string ApplicationNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
