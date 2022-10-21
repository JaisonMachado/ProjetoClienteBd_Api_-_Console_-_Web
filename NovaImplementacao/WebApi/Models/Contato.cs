using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Contato
    {
        [Key()]
        public int ContatoId { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool ContatoAtivo { get; set; }
        public int ClienteId { get; set; }
    }
}
