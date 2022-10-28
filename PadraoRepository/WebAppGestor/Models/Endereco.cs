namespace WebAppGestor.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public bool EnderecoAtivo { get; set; }
        public int ClienteId { get; set; }
    }
}
