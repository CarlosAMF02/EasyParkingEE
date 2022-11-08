using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace WebAppGlobal.Models
{
    public class Estacionamento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco? Endereco { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + ", Nome: " + Nome + ", Endereco: " + Endereco;
        }
    }
}
