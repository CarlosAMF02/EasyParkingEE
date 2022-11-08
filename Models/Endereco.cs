using System.ComponentModel.DataAnnotations;

namespace WebAppGlobal.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + ", Rua: " + Rua + ", Bairro: " + Bairro + " Numero: " + Numero + ", Cidade: " + Cidade + ", Estado: " + Estado;
        }
    }
}
