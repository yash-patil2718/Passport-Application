using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.Feedback;
using PassportWebApplication.Enums;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PassportContext _context;

        public FeedbackController(IUnitofWork unitofWork, PassportContext context)
        {
            _unitofWork = unitofWork;
            _context = context;
        }

        [HttpPost("feedback")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<FeedbackDto>> AddFeeback(FeedbackDto feedbackDto)
        {
            var user = await _unitofWork.UserRepository.GetUserByEmail(feedbackDto.Email);
            if (user == null) {
                return BadRequest("Email is invalid");
            }

            var feedback = new Feedback
            {
                UserId = user.UserId,
                Email = feedbackDto.Email,
                FeedbackType = feedbackDto.FeedbackType,
                Username = feedbackDto.Username,
                Description = feedbackDto.Description,
                Status = FeedbackEnum.New,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };
            await _unitofWork.FeedbackRepository.AddAsync(feedback);

            return Ok(feedback);
        }
        

        

    }
}
