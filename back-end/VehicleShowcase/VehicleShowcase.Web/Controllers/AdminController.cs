using Microsoft.AspNetCore.Mvc;
using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.AdminUser;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;                
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAdminResponseDTO>> GetAdminByIdAsync(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);

            if (admin is null)
                return NotFound(admin);

            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<GetAdminResponseDTO>> AddAdminAsync(AddAdminRequestDTO newAdmin)
        {
            var admin = await _adminService.AddAdminAsync(newAdmin);

            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAsync(int id)
        {
            await _adminService.DeleteAdminAsync(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetAdminResponseDTO>> UpdateAdminAsync(int id, EditAdminRequestDTO newAdmin)
        {
            var admin = await _adminService.UpdateAdminAsync(id, newAdmin);

            if (admin is null)
                return NotFound(admin);

            return Ok(admin);
        }
    }
}
