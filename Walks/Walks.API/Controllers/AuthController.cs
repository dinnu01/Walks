using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.Domains;
using Walks.API.Models.DTOs;
using Walks.API.Repositories;

namespace Walks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
           User user= await _userRepository.AuntenticateAsync(loginDto.UserName, loginDto.Password);
            if (user!=null) {
              var token= await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("invalid credentioals");
        }
    }
}
