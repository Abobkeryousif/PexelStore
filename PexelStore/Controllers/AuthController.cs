using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PexelStore.Models.Domain;
using PexelStore.Repository;

namespace PexelStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _manager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> manager,ITokenRepository tokenRepository)
        {
            _manager = manager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateAsync(Register register )
        {

            var IdentityUser = new IdentityUser()
            {
                Email = register.Email,
                UserName = register.UserName,
                PhoneNumber = register.PhoneNumber,
            };

            var result = await _manager.CreateAsync(IdentityUser , register.Password);
            if (result.Succeeded) 
            {
                if (register.Roles != null && register.Roles.Any()) 
                {
                result = await _manager.AddToRolesAsync(IdentityUser, register.Roles);
                }

                if(result.Succeeded)
                {

                    return Ok($"Sgin UP Complete:{register.UserName} Plaese Login!");
                }

                
            }
            return BadRequest("Something Wrong!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(Login login) 
        {
            var user = await _manager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var ChaeckPassword = await _manager.CheckPasswordAsync(user, login.Password);
                if(ChaeckPassword) { 
                var role = await _manager.GetRolesAsync(user);
                    if (role != null) 
                    {
                        var jwtToken = _tokenRepository.CreateToken(user, role.ToList());
                        return Ok(jwtToken);
                    
                    }
                }

            }
            return BadRequest("Email Or Password Is Wrong!");
        }
    }
}




