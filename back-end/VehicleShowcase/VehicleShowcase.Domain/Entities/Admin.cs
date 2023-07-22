using VehicleShowcase.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowcase.Domain.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}