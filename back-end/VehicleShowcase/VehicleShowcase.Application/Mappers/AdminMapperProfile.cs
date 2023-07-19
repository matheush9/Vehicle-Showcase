using AutoMapper;
using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;
using VehicleShowcase.Domain.Entities;

namespace VehicleShowcase.Application.Mappers
{
    public class AdminMapperProfile: Profile
    {
        public AdminMapperProfile()
        {
            CreateMap<Admin, GetAdminResponseDTO>();
            CreateMap<Admin, AddAdminRequestDTO>();
            CreateMap<AddAdminRequestDTO, Admin>();
        }
    }
}