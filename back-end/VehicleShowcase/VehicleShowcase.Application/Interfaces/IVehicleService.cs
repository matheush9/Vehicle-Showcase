using VehicleShowcase.Application.DTOs.Vehicle;

namespace VehicleShowcase.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<GetVehicleResponseDTO> GetVehicleByIdAsync(int id);
        Task<GetVehicleResponseDTO> AddVehicleAsync(AddVehicleRequestDTO newVehicle);
        Task<GetVehicleResponseDTO> DeleteVehicleAsync(int id);
        Task<GetVehicleResponseDTO> UpdateVehicleAsync(int id, AddVehicleRequestDTO newVehicle);
    }
}