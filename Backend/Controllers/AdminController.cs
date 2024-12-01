using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.AdminDto;
using PassportWebApplication.DTO.Feedback;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly PassportContext _context;

        public AdminController(IUnitofWork unitofWork, PassportContext context, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _context = context;
            _mapper = mapper;
        }

        // get all feedbacks
        [HttpGet("feedbacks")]
        public async Task<IEnumerable<AdminFeedbackDto>> GetAllFeedbacks() 
        {
            IEnumerable<Feedback> data = await _unitofWork.AdminRepository.GetAllFeedbacks();
            IEnumerable<AdminFeedbackDto> feedbacks = _mapper.Map<IEnumerable<AdminFeedbackDto>>(data);
            return feedbacks;
        }

        //get all complaints
        [HttpGet("complaints")]
        public async Task<IEnumerable<AdminFeedbackDto>> GetAllComplaints()
        {
            try {
                IEnumerable<Feedback> data = await _unitofWork.AdminRepository.GetAllComplaints();
                IEnumerable<AdminFeedbackDto> complaints = _mapper.Map<IEnumerable<AdminFeedbackDto>>(data);
                return complaints;
            } catch (Exception ex) 
            {
                return null;
            } 
        }

        // update Complaint Status
        [HttpPut("updateComplaint")]
        public async Task<IActionResult> UpdateComplaintStatus(AdminFeedbackDto model)
        {
            try
            {
                await _unitofWork.AdminRepository.UpdateCustomerComplaint(model);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
            
        }

        //Get all New Applications
        [HttpGet("newapplications")]
        public async Task<IEnumerable<UpdateApplicationDto>> GetAllNewApplications()
        {
            IEnumerable<UpdateApplicationDto> data = await _unitofWork.AdminRepository.GetAllNewApplications();
            return data;
        }

        //get all renew applications
        [HttpGet("renewapplications")]
        public async Task<IEnumerable<UpdateApplicationDto>> GetAllRenewApplications()
        {
            IEnumerable<UpdateApplicationDto> data = await _unitofWork.AdminRepository.GetAllRenewApplications();
            return data;
        }

        //update New Application details
        [HttpPut("updateapplication")]
        public async Task<IActionResult> UpdateApplicationStatus(UpdateApplicationDto model) 
        {
            try
            {
                await _unitofWork.AdminRepository.UpdateApplicationStatus(model);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        //Get All User
        [HttpGet("userlist")]
        public async Task<IActionResult> GetAllUsers() 
        {
            try 
            {
                 IEnumerable<UserListDto> UserList = await _unitofWork.AdminRepository.GetAllUsersAsync();
                 return Ok(UserList);

            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            } 
        }
    }
}
