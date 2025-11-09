using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PDFShelf.Api.Models;

namespace PDFShelf.Api.Services
{
    public class TokenService
    {
        private readonly string _privateKey;
        public TokenService(IConfiguration config)
        {
            _privateKey = config["Jwt:PrivateKey"] ?? throw new ArgumentNullException("Jwt:PrivateKey");
        }

        public string Generate(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_privateKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email),
                new("UserId", user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}