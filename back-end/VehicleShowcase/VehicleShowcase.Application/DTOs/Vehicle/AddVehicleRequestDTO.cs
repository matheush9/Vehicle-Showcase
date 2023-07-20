namespace VehicleShowcase.Application.DTOs.Vehicle
{
    public class AddVehicleRequestDTO
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Foto { get; set; }
        public decimal Preco { get; set; }
    }
}
