using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Application.Services
{
    public class AdminService : IAdminService
    {
        public async Task<GetAdminResponseDTO> AddAdminAsync(AddAdminRequestDTO newAdmin)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAdminResponseDTO> DeleteAdminAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAdminResponseDTO> GetAdminByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAdminResponseDTO> UpdateAdminAsync(int id, AddAdminRequestDTO newAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
