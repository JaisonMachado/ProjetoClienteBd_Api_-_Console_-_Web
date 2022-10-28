using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Endereco
    {
        [Key()]
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public bool EnderecoAtivo { get; set; }
        public int ClienteId { get; set; }
    }
}
