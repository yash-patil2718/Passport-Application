using PassportWebApplication.Enums;

namespace PassportWebApplication.DTO.AdminDto
{
    public class UpdateApplicationDto
    {
        public string ApplicantName { get; set; }
        public string ApplicationNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
