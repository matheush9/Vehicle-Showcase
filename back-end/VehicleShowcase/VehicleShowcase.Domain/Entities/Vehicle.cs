using VehicleShowcase.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowcase.Domain.Entities
{
    public class Vehicle : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Foto { get; set; }
    }
}