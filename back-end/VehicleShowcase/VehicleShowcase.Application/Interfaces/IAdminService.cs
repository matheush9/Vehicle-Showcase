using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;

namespace VehicleShowcase.Application.Interfaces
{
    public interface IAdminService
    {
        Task<GetAdminResponseDTO> GetAdminByIdAsync(int id);
        Task<GetAdminResponseDTO> AddAdminAsync(AddAdminRequestDTO newAdmin);
        Task DeleteAdminAsync(int id);
        Task<GetAdminResponseDTO> UpdateAdminAsync(int id, EditAdminRequestDTO newAdmin);
    }
}