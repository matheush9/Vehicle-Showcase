using VehicleShowcase.Application.DTOs.JwtToken;
using VehicleShowcase.Domain.Entities;

namespace VehicleShowcase.Application.Interfaces
{
    public interface ITokenService
    {
        JwtTokenResponseDto GenerateToken(Admin admin);
    }
}
