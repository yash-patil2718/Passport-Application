using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.NewApplication;
using PassportWebApplication.Enums;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Controllers
{
    public class NewApplication
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly MasterDetails _masterDetails;
        private readonly PassportContext _context;
        public NewApplication(IUnitofWork unitOfWork, PassportContext context)
        {
            _unitOfWork = unitOfWork;
            _masterDetails = new MasterDetails();
            _context = context;
        }
        public void InItMasterData(NewApplicationDto newPassportApplyDTO)
        {
            _masterDetails.ApplicationNo = newPassportApplyDTO.ApplicationNo;
            _masterDetails.ApplicationStatus = Enums.ApplicationStatus.New;
            _masterDetails.PassportType = PassportType.New;
            _masterDetails.PaymentStatus = PaymentStatus.Unpaid;
            _masterDetails.UserId = newPassportApplyDTO.UserId;
            _masterDetails.CreatedOn = DateTime.Now;
            _masterDetails.UpdatedOn = DateTime.Now;
        }
        public void InItRenewMasterData(NewApplicationDto newPassportApplyDTO)
        {
            _masterDetails.ApplicationNo = newPassportApplyDTO.ApplicationNo;
            _masterDetails.ApplicationStatus = Enums.ApplicationStatus.New;
            _masterDetails.PassportType = PassportType.Renewal;
            _masterDetails.PaymentStatus = PaymentStatus.Unpaid;
            _masterDetails.UserId = newPassportApplyDTO.UserId;
            _masterDetails.CreatedOn = DateTime.Now;
            _masterDetails.UpdatedOn = DateTime.Now;
        }
        public async Task AddServiceRequired(ServiceRquired serviceRequired)
        {
            await _unitOfWork.ServiceRepository.CreateServiceRequiredAsync(serviceRequired);
            _masterDetails.ServiceRequiredId = serviceRequired.ServiceRequiredId;
        }
        public async Task AddApplicantDetails(ApplicantDetails applicantDetails)
        {
            await _unitOfWork.ApplicantRepository.CreateApplicantDetailsAsync(applicantDetails);
            _masterDetails.ApplicntDetailsId = applicantDetails.ApplicntDetailsId;
        }
        public async Task AddResidentailDetails(ResidentialDetails residentailDetails)
        {
            await _unitOfWork.ResidentialRepository.CreateResidentialDetailsAsync(residentailDetails);
            _masterDetails.ResidentialDetailsId = residentailDetails.ResidentialDetailsId;
        }
        public async Task AddFamilyDetails(FamilyDetails familyDetails)
        {
            await _unitOfWork.FamilyRepository.CreateFamilyDetailsAsync(familyDetails);
            _masterDetails.FamilyDetailsId = familyDetails.FamilyDetailsId;
        }
        public async Task AddEmergencyContactDetails(EmergencyDetails emergencyContactDetails)
        {
            await _unitOfWork.EmergencyRepository.CreateEmergencyDetailsAsync(emergencyContactDetails);
            _masterDetails.EmergencyDetailsId = emergencyContactDetails.EmergencyDetailsId;
        }
        public async Task AddOtherDetails(OtherDetails otherDetails)
        {
            await _unitOfWork.OtherRepository.CreateOtherDetailsAsync(otherDetails);
            _masterDetails.OtherDetailsId = otherDetails.OtherDetailsId;
        }

        public async Task AddSelfDeclaration( Documents selfDeclaration)
        {

            try
            {
               
                await _unitOfWork.DocumentsRepository.CreateDocumentAsync(selfDeclaration);
                _masterDetails.DocumentsId = selfDeclaration.DocumentsId;
                await _unitOfWork.MasterDetailsRepository.CreateMasterDetailsAsync(_masterDetails);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GenerateUniqueApplicationNo()
        {
            // Using Random to generate a 10-digit number
            Random random = new Random();
            string uniqueNumber = random.Next(1000000000, 2000000000).ToString();

            return uniqueNumber;
        }

    }
}
