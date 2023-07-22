using Microsoft.AspNetCore.Http;

namespace VehicleShowcase.Application.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> UploadImage(IFormFile image);
    }
}
