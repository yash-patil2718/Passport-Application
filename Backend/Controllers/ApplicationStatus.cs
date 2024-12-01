using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.ApplicationStatusDto;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatus : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PassportContext _context;
        private readonly IMapper _mapper;
        public ApplicationStatus(IUnitofWork unitofWork, PassportContext context, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _context = context;
            _mapper = mapper;
        }

        // track the application status
        [HttpPost("trackapplication")]
        public async Task<IActionResult> GetApplicationDetails([FromBody] TrackApplicationDto trackApplicationDto) 
        {
            try
            {
                var applicationDetails = await _unitofWork.MasterDetailsRepository.GetApplicationStatusDetails(trackApplicationDto);
                if (applicationDetails == null) 
                {
                    return NotFound();
                }

                return Ok(applicationDetails);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
