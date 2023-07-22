using System.ComponentModel.DataAnnotations;

namespace VehicleShowcase.Application.DTOs.Vehicle
{
    public class AddVehicleRequestDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        public string Foto { get; set; }
        public decimal Preco { get; set; }
    }
}
