using VehicleShowcase.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowcase.Domain.Entities
{
    public class Admin : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Admin(int Id, string Nome, string Usuario, string Senha)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Usuario = Usuario;
            this.Senha = Senha;           
        }
    }
}