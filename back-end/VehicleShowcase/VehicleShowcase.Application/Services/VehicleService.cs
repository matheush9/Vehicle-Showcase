using VehicleShowcase.Application.DTOs.Vehicle;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Application.Services
{
    public class VehicleService : IVehicleService
    {
        public async Task<GetVehicleResponseDTO> AddVehicleAsync(AddVehicleRequestDTO newVehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<GetVehicleResponseDTO> DeleteVehicleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetVehicleResponseDTO> GetVehicleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetVehicleResponseDTO> UpdateVehicleAsync(int id, AddVehicleRequestDTO newVehicle)
        {
            throw new NotImplementedException();
        }
    }
}
