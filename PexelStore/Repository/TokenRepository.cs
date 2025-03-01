using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PexelStore.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(IdentityUser user, List<string> Roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in Roles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var Cerdentail = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken
                (
                _configuration["Jwt:Issure"],
                _configuration["Jwt:Audience"],
                claims,
                signingCredentials : Cerdentail,
                expires: DateTime.UtcNow.AddMinutes(10)
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
            
        }
    }
}
