using AutoMapper;
using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;
using VehicleShowcase.Application.Interfaces;
using VehicleShowcase.Domain.Entities;
using VehicleShowcase.Infrastructure.Data;

namespace VehicleShowcase.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<GetAdminResponseDTO> GetAdminByIdAsync(int id)
        {
            var admin = await _dataContext.Admins.FindAsync(id);

            return _mapper.Map<GetAdminResponseDTO>(admin);
        }

        public async Task<GetAdminResponseDTO> AddAdminAsync(AddAdminRequestDTO newAdmin)
        {
            var admin = _mapper.Map<Admin>(newAdmin);
            await _dataContext.Admins.AddAsync(admin);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<GetAdminResponseDTO>(admin);
        }

        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _dataContext.Admins.FindAsync(id);
 
            if (admin is not null)
            {
                _dataContext.Admins.Remove(admin);

                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<GetAdminResponseDTO> UpdateAdminAsync(int id, EditAdminRequestDTO newAdmin)
        {
            var admin = await _dataContext.Admins.FindAsync(id);

            if (admin is not null)
            {
                admin.Nome = newAdmin.Nome;
                admin.Usuario = newAdmin.Usuario;

                await _dataContext.SaveChangesAsync();
            }

            return _mapper.Map<GetAdminResponseDTO>(admin);
        }
    }
}
