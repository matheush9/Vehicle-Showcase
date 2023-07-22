using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleShowcase.Application.DTOs.Admin;
using VehicleShowcase.Application.DTOs.Vehicle;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetVehicleResponseDTO>> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);

            if (vehicle is null)
                return NotFound(vehicle);

            return Ok(vehicle);
        }

        [HttpGet("ordered-by-price")]
        public async Task<ActionResult<List<GetVehicleResponseDTO>>> GetAllVehiclesOrderByPriceAsync()
        {
            return await _vehicleService.GetAllVehiclesOrderByPriceAsync();
        }

        [HttpGet("ordered-by-descending")]
        public async Task<ActionResult<List<GetVehicleResponseDTO>>> GetAllVehiclesOrderByDescending()
        {
            return await _vehicleService.GetAllVehiclesOrderByDescending();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<GetAdminResponseDTO>> AddVehicleAsync(AddVehicleRequestDTO newVehicle)
        {
            var vehicle = await _vehicleService.AddVehicleAsync(newVehicle);
            return Ok(vehicle);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            await _vehicleService.DeleteVehicleAsync(id);

            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<GetAdminResponseDTO>> UpdateVehicleAsync(int id, AddVehicleRequestDTO newVehicle)
        {
            var vehicle = await _vehicleService.UpdateVehicleAsync(id, newVehicle);

            if (vehicle is null)
                return NotFound(vehicle);

            return Ok(vehicle);
        }

        [Authorize]
        [HttpPost("upload/image")]
        public async Task<ActionResult<GetAdminResponseDTO>> UploadVehicleImageAsync([FromForm] int vehicleId, [FromForm] IFormFile image)
        {
            return Ok(await _vehicleService.UploadVehicleImageAsync(vehicleId, image));
        }
    }
}