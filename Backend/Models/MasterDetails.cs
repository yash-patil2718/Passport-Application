using PassportWebApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.Models
{
    public class MasterDetails
    {
        [Key]
        public int MasterDetailsId { get; set; }
        public string ApplicationNo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; } // enum
        public PassportType PassportType { get; set; }  //enum 
        public PaymentStatus PaymentStatus { get; set; }  // enum
        public int PaymentId { get; set; }
        
        // navigation property for service required
        public int ServiceRequiredId { get; set; }
        public ServiceRquired ServiceRquired { get; set; }

        // navigation property 
        public int ApplicntDetailsId { get; set; }
        public ApplicantDetails ApplicantDetails { get; set; }

        // navigation property 
        public int FamilyDetailsId { get; set; }
        public FamilyDetails FamilyDetails { get; set; }

        // navigation property 
        public int ResidentialDetailsId { get; set; }
        public ResidentialDetails ResidentialDetails { get; set; }


        // navigation property 
        public int EmergencyDetailsId { get; set; }
        public EmergencyDetails EmergencyDetails { get; set; }


        // navigation property 
        public int OtherDetailsId { get; set; }
        public OtherDetails OtherDetails { get; set; }

        // navigation property 
        public int DocumentsId { get; set; }
        public Documents Documents { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }
        
    }

}
