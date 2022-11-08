using System.ComponentModel.DataAnnotations;

namespace WebAppGlobal.Models
{
    public class Vaga
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Andar { get; set; }
        public char Status { get; set; }
        public Estacionamento Estacionamento { get; set; }
    }
}
