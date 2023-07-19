using VehicleShowcase.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowcase.Domain.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}