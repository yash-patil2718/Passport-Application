using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.NewApplication;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewApplicationController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PassportContext _context;
        private readonly IMapper _mapper;
        public NewApplicationController(IUnitofWork unitofWork, PassportContext context, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _context = context;
            _mapper = mapper;
        }


        //  Post Method for Submitting the application
        [HttpPost("newapplication")]
        public async Task<IActionResult> ApplyForNewApplication( NewApplicationDto newApplicationDto) 
        {
            try
            {
                var serviceModel = _mapper.Map<ServiceRquired>(newApplicationDto.ServiceRequiredDto);
                var applicantModel = _mapper.Map<ApplicantDetails>(newApplicationDto.ApplicntDetailsDto);
                var familyModel = _mapper.Map<FamilyDetails>(newApplicationDto.FamilyDetailsDto);
                var residentialModel = _mapper.Map<ResidentialDetails>(newApplicationDto.ResidentialDetailsDto);
                var emergencyModel = _mapper.Map<EmergencyDetails>(newApplicationDto.EmergencyDetailsDto);
                var otherModel = _mapper.Map<OtherDetails>(newApplicationDto.OtherDetailsDto);
                var documentModel = _mapper.Map<Documents>(newApplicationDto.DocumentsDto);

                NewApplication newApplication = new NewApplication(_unitofWork, _context);

                newApplication.InItMasterData(newApplicationDto);
                await newApplication.AddServiceRequired(serviceModel);
                await newApplication.AddApplicantDetails(applicantModel);
                await newApplication.AddResidentailDetails(residentialModel);
                await newApplication.AddFamilyDetails(familyModel);
                await newApplication.AddEmergencyContactDetails(emergencyModel);
                await newApplication.AddOtherDetails(otherModel);
                await newApplication.AddSelfDeclaration(documentModel);


                return NoContent();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error Occurred during saving details");
            }
        }

         




    }
}
