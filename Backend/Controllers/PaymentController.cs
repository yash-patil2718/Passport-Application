using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.ApplicationStatusDto;
using PassportWebApplication.DTO.NewApplication;
using PassportWebApplication.Repository.IRepository;

namespace PassportWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PassportContext _context;
        private readonly IMapper _mapper;
        public PaymentController(IUnitofWork unitofWork, PassportContext context, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _context = context;
            _mapper = mapper;
        }


        // updating the status when user pay
        [HttpPut("payment")]
        public async Task<IActionResult> MakePaymentForApplication(PaymentUpdateDto modelDto) 
        {
            try
            {
                var result =  await _unitofWork.UserRepository.MakePaymentForApplication(modelDto);
                if (result == null) {
                    return BadRequest(null);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
