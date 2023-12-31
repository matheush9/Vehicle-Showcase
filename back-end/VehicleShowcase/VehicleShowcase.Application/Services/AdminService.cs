﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;
using VehicleShowcase.Application.DTOs.JwtToken;
using VehicleShowcase.Application.Interfaces;
using VehicleShowcase.Domain.Entities;
using VehicleShowcase.Infrastructure.Data;

namespace VehicleShowcase.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AdminService(DataContext dataContext, IMapper mapper, ITokenService tokenService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<GetAdminResponseDTO> GetAdminByIdAsync(int id)
        {
            var admin = await _dataContext.Admins.FindAsync(id);

            return _mapper.Map<GetAdminResponseDTO>(admin);
        }

        public async Task<GetAdminResponseDTO> AddAdminAsync(AddAdminRequestDTO newAdmin)
        {
            var admin = _mapper.Map<Admin>(newAdmin);
            admin.Senha = PasswordHasherService.HashPassword(newAdmin.Senha);

            await _dataContext.Admins.AddAsync(admin);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<GetAdminResponseDTO>(admin);
        }

        [Authorize]
        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _dataContext.Admins.FindAsync(id);
 
            if (admin is not null)
            {
                _dataContext.Admins.Remove(admin);

                await _dataContext.SaveChangesAsync();
            }
        }

        [Authorize]
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

        public async Task<JwtTokenResponseDto> Authenticate(AddAdminRequestDTO adminRequest)
        {
            var admin = await _dataContext.Admins.FirstOrDefaultAsync(x => x.Usuario == adminRequest.Usuario);

            if (admin is not null && PasswordHasherService.VerifyPasswordMatching(adminRequest.Senha, admin.Senha))
                return _tokenService.GenerateToken(admin);

            return new JwtTokenResponseDto();
        }
    }
}