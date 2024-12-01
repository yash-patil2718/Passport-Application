using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PassportWebApplication.Data;
using PassportWebApplication.DTO.Auth;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PassportWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<PassportUser> _userManager;
        private readonly SignInManager<PassportUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly IUnitofWork _unitofWork;
        private readonly IJWTTokenService _jwtTokenService;
        private readonly PassportContext _context;
        //Dependency injection using Constructor
        public AuthController(UserManager<PassportUser> userManager, 
                              SignInManager<PassportUser> signInManager,
                              IConfiguration config,
                              IUnitofWork unitofWork,
                              IJWTTokenService jwtTokenService,
                              PassportContext context)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitofWork = unitofWork;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }

        //API for Login purpose 

        [HttpPost("login")]
        public async Task<ActionResult<LoggedInUser>> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == model.Username);
            if (user == null) {
                return Unauthorized("Invalid Username.");    
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded) 
            {
                return Unauthorized("Username or Password is incorrect.");
            }
            else {
                var roles = await _userManager.GetRolesAsync(user);
                var userData =  _context.Users.FirstOrDefault(u => u.PassportUserId == user.Id);
                var loggedInUser = new LoggedInUser
                {
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Email = user.Email,
                    PhoneNo = user.PhoneNumber,
                    UserName = userData.UserName,
                    UserId = userData.UserId,
                    Token = await _jwtTokenService.GenerateToken(user),
                    Role = roles.FirstOrDefault(),
                    Expiration = DateTime.Now.AddHours(3),
                };
                return Ok(loggedInUser);
            }
        }


        // method for signup / register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            // Check if the username already exists
            var existingUser =  _context.Users.FirstOrDefault(user => user.UserName == model.Username);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Username already exists. Please choose a different username." });
            }
            var identityUser = new PassportUser
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Mobileno,

            };
            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                
                await _userManager.AddToRoleAsync(identityUser, "User");

                // saving the details in user table
                var user = new User
                {
                    FirstName = model.Firstname,
                    MiddleName = model.Middlename,
                    LastName = model.Lastname,
                    Email = model.Email,
                    Password = model.Password, 
                    PhoneNo = model.Mobileno,
                    UserName = model.Username,
                    PassportUserId = identityUser.Id,  // Foreign key reference to IdentityUser
                    DOB = DateTime.Parse(model.DOB.ToString()),  // Ensure correct conversion from DateOnly to DateTime
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                };

                  await _unitofWork.UserRepository.AddAsync(user);

                return Ok(new { message = "User registered successfully" });
            }

            return BadRequest(result.Errors);
        }

    }
}
