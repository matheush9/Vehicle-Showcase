using AutoMapper;
using VehicleShowcase.Application.DTOs.Vehicle;
using VehicleShowcase.Domain.Entities;

namespace VehicleShowcase.Application.Mappers
{
    public class VehicleMapperProfile : Profile
    {
        public VehicleMapperProfile()
        {
            CreateMap<Vehicle, GetVehicleResponseDTO>();
            CreateMap<Vehicle, AddVehicleRequestDTO>();
            CreateMap<AddVehicleRequestDTO, Vehicle>();
        }
    }
}