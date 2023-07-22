using System.ComponentModel.DataAnnotations;

namespace VehicleShowcase.Application.DTOs.AdminUser
{
    public class AddAdminRequestDTO
    {
        public string Nome { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
