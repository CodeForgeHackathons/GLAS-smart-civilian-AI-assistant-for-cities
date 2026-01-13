using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using GLAS_Server.Services.Interfaces;

namespace GLAS_Server.Services
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly IConfiguration _config;

        public JwtTokenProvider(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(uint userId, string phoneNumber)
        {
            var secretKey = _config["Jwt:SecretKey"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiresInMinutes = int.Parse(_config["Jwt:ExpiresInMinutes"] ?? "60");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.MobilePhone, phoneNumber),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
