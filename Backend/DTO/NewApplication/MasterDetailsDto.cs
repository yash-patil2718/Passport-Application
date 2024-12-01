using PassportWebApplication.Enums;
using PassportWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace PassportWebApplication.DTO.NewApplication
{
    public class MasterDetailsDto
    {
        public int MasterDetailsId { get; set; }
        public string ApplicationNo { get; set; }
        public int UserId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; } // enum
        public PassportType PassportType { get; set; }  //enum 
        public PaymentStatus PaymentStatus { get; set; }  // enum
        public int ?PaymentId { get; set; }

        public int ServiceRequiredId { get; set; }

        // navigation property 
        public int ApplicntDetailsId { get; set; }

        // navigation property 
        public int FamilyDetailsId { get; set; }

        // navigation property 
        public int ResidentialDetailsId { get; set; }

        // navigation property 
        public int EmergencyDetailsId { get; set; }


        // navigation property 
        public int OtherDetailsId { get; set; }

        // navigation property 
        public int DocumentsId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }
    }
}
