using AutoMapper;
using VehicleShowcase.Application.DTOs.Vehicle;
using VehicleShowcase.Application.Interfaces;
using VehicleShowcase.Domain.Entities;
using VehicleShowcase.Infrastructure.Data;

namespace VehicleShowcase.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public VehicleService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<GetVehicleResponseDTO> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _dataContext.Vehicles.FindAsync(id);

            return _mapper.Map<GetVehicleResponseDTO>(vehicle);
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

                await _dataContext.SaveChangesAsync();
            }

            return _mapper.Map<GetVehicleResponseDTO>(vehicle);
        }
    }
}
