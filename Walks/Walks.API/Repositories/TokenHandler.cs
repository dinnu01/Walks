using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Walks.API.Models.Domains;

namespace Walks.API.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _con;
        public TokenHandler(IConfiguration con)
        {
            _con = con;
        }
        public  Task<string> CreateTokenAsync(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName,user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.EmailAddress));

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_con["JWT:Key"]));
            var credintials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                 _con["JWT:Issuer"],
                 _con["JWT:Audience"],
                 claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credintials
                );
          return  Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
