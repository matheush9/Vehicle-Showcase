using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VehicleShowcase.Application.DTOs.JwtToken;
using VehicleShowcase.Domain.Entities;

namespace VehicleShowcase.Application.Services
{
    public class TokenService
    {
        public static JwtTokenResponseDto GenerateToken(Admin admin)
        {
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("AdminId", admin.Id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(PrivateKeyService.privateKey), SecurityAlgorithms.HmacSha256Signature)
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
