using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;
using VehicleShowcase.Application.DTOs.JwtToken;

namespace VehicleShowcase.Application.Interfaces
{
    public interface IAdminService
    {
        Task<GetAdminResponseDTO> GetAdminByIdAsync(int id);
        Task<GetAdminResponseDTO> AddAdminAsync(AddAdminRequestDTO newAdmin);
        Task DeleteAdminAsync(int id);
        Task<GetAdminResponseDTO> UpdateAdminAsync(int id, EditAdminRequestDTO newAdmin);
        Task<JwtTokenResponseDto> Authenticate(AddAdminRequestDTO adminRequest);
    }
}