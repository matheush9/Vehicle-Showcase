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

        public Vehicle(int Id, string Nome, string Marca, string Modelo, string Foto)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Foto = Foto;
        }
    }
}