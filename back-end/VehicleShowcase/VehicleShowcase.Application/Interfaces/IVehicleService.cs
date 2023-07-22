using Microsoft.AspNetCore.Http;
using VehicleShowcase.Application.DTOs.Vehicle;

namespace VehicleShowcase.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<GetVehicleResponseDTO> GetVehicleByIdAsync(int id);
        Task<List<GetVehicleResponseDTO>> GetAllVehiclesOrderByPriceAsync();
        Task<List<GetVehicleResponseDTO>> GetAllVehiclesOrderByDescending();
        Task<GetVehicleResponseDTO> AddVehicleAsync(AddVehicleRequestDTO newVehicle);
        Task<GetVehicleResponseDTO> UploadVehicleImageAsync(int vehicleId, IFormFile image);
        Task DeleteVehicleAsync(int id);
        Task<GetVehicleResponseDTO> UpdateVehicleAsync(int id, AddVehicleRequestDTO newVehicle);
    }
}