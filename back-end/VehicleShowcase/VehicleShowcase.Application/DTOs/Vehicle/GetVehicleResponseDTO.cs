namespace VehicleShowcase.Application.DTOs.Vehicle
{
    public class GetVehicleResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Foto { get; set; }
        public decimal Preco { get; set; }
    }
}
