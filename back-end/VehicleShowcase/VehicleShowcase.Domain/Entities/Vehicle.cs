using VehicleShowcase.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleShowcase.Domain.Entities
{
    public class Vehicle : Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        public string Foto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
    }
}