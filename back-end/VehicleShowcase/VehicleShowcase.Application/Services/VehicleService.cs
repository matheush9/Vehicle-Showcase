using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VehicleShowcase.Application.DTOs.Vehicle;
using VehicleShowcase.Application.Interfaces;
using VehicleShowcase.Domain.Entities;
using VehicleShowcase.Infrastructure.Data;

namespace VehicleShowcase.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper; 
        private readonly IImageUploadService _imageUploadService;
        private readonly DataContext _dataContext;

        public VehicleService(DataContext dataContext, IMapper mapper, IImageUploadService imageUploadService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        public async Task<GetVehicleResponseDTO> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _dataContext.Vehicles.FindAsync(id);

            return _mapper.Map<GetVehicleResponseDTO>(vehicle);
        }

        public async Task<List<GetVehicleResponseDTO>> GetAllVehiclesOrderByPriceAsync()
        {
            var vehicles = await _dataContext.Vehicles.OrderBy(p => p.Preco).ToListAsync();

            return _mapper.Map<List<GetVehicleResponseDTO>>(vehicles);
        }

        public async Task<List<GetVehicleResponseDTO>> GetAllVehiclesOrderByDescending()
        {
            var vehicles = await _dataContext.Vehicles.OrderByDescending(v => v.Id).ToListAsync();

            return _mapper.Map<List<GetVehicleResponseDTO>>(vehicles);
        }

        public async Task<GetVehicleResponseDTO> AddVehicleAsync(AddVehicleRequestDTO newVehicle)
        {
            var vehicle = _mapper.Map<Vehicle>(newVehicle);
            await _dataContext.Vehicles.AddAsync(vehicle);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<GetVehicleResponseDTO>(vehicle);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _dataContext.Vehicles.FindAsync(id);

            if (vehicle is not null)
            {
                _dataContext.Vehicles.Remove(vehicle);

                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<GetVehicleResponseDTO> UpdateVehicleAsync(int id, AddVehicleRequestDTO newVehicle)
        {
            var vehicle = await _dataContext.Vehicles.FindAsync(id);

            if (vehicle is not null)
            {
                vehicle.Nome = newVehicle.Nome;
                vehicle.Modelo = newVehicle.Modelo;
                vehicle.Marca = newVehicle.Marca;
                vehicle.Foto = newVehicle.Foto;
                vehicle.Preco = newVehicle.Preco;

                await _dataContext.SaveChangesAsync();
            }

            return _mapper.Map<GetVehicleResponseDTO>(vehicle);
        }

        public async Task<GetVehicleResponseDTO> UploadVehicleImageAsync(int vehicleId, IFormFile image)
        {
            var imagePath = await _imageUploadService.UploadImage(image);
            var vehicle = await _dataContext.Vehicles.FindAsync(vehicleId);

            if (vehicle is not null)
            {
                vehicle.Foto = imagePath;

                await _dataContext.SaveChangesAsync();
            }

            return _mapper.Map<GetVehicleResponseDTO>(vehicle);
        }
    }
}
