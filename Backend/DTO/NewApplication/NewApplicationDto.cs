using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.NewApplication
{
    public class NewApplicationDto
    {
        /* 
         public int ?UserId { get; set; }
         public string ?PassportNo { get; set; }
         public ApplicationStatus ApplicationStatus { get; set; } // enum
         public PassportType PassportType { get; set; }  //enum 
         public PaymentStatus PaymentStatus { get; set; }  // enum*/
        //public int? PaymentId { get; set; }
        public string? ApplicationNo { get; set; }
        public int UserId { get; set; }

        public ServiceRequiredDto ServiceRequiredDto { get; set; }

        // navigation property 
        public ApplicantDetailsDto ApplicntDetailsDto { get; set; }

        // navigation property 
        public FamilyDetailsDto FamilyDetailsDto { get; set; }

        // navigation property 
        public ResidentialDetailsDto ResidentialDetailsDto { get; set; }

        // navigation property 
        public EmergencyDetailsDto EmergencyDetailsDto { get; set; }


        // navigation property 
        public OtherDetailsDto OtherDetailsDto { get; set; }

        // navigation property 
        public DocumentDetailsDto DocumentsDto { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime CreatedOn { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime UpdatedOn { get; set; }
    }
}
