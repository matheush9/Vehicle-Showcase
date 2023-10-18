using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VehicleShowcase.Application.DTOs.JwtToken;
using VehicleShowcase.Application.Interfaces;
using VehicleShowcase.Domain.Entities;

namespace VehicleShowcase.Application.Services
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public JwtTokenResponseDto GenerateToken(Admin admin)
        {
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("AdminId", admin.Id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);

            var jwtTokenResponse = new JwtTokenResponseDto
            {
                accessToken = tokenHandler.WriteToken(token),
                IssuedAt = DateTime.UtcNow,
                ExpirationTime = tokenConfig.Expires
            };

            return jwtTokenResponse;
        }
    }
}
