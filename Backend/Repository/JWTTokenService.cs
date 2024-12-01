using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PassportWebApplication.Models;
using PassportWebApplication.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PassportWebApplication.Repository
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly UserManager<PassportUser> _userManager;
        private readonly IConfiguration _config;

        public JWTTokenService(UserManager<PassportUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        public async Task<string> GenerateToken(PassportUser userData)
        {
            var userRoles = await _userManager.GetRolesAsync(userData);
            var authClaims = new List<Claim>
         {
             new Claim(ClaimTypes.Role, userData.UserName),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
         };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
