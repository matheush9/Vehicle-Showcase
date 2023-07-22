using Microsoft.AspNetCore.Http;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Application.Services
{
    public class ImageUploadService : IImageUploadService
    {
        public async Task<string> UploadImage(IFormFile image)
        {
            if (image is not null && image.Length > 0)
            {
                if (image.ContentType.Contains("image"))
                {
                    var memoryStream = new MemoryStream();
                    await image.CopyToAsync(memoryStream);

                    string[] fullPath = CreateImagePath(image).Split('#');

                    await File.WriteAllBytesAsync(fullPath[0], memoryStream.ToArray());

                    return fullPath[1];
                }
            }
            return "Invalid image";
        }

        private string CreateImagePath(IFormFile image)
        {
            string localPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            if (!Directory.Exists(localPath))
                Directory.CreateDirectory(localPath);

            localPath = Path.Combine(localPath, filename);

            string remotePath = "/Images" + "/" + filename;

            return localPath + '#' + remotePath;
        }
    }
}
