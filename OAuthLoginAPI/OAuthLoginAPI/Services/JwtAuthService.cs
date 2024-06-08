using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OAuthLoginAPI.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration _configuration;

        public JwtAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string username, IEnumerable<string> roles, IEnumerable<string> scopes)
        {
            var jwtSecret = _configuration["AppSettings:JwtSecret"];
            if (!string.IsNullOrEmpty(jwtSecret))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSecret);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
            };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                foreach (var scope in scopes)
                {
                    claims.Add(new Claim("scope", scope));
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return "Invalid JWT Token Secret";
        }
    }
}
