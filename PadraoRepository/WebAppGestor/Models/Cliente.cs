namespace WebAppGestor.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string Cpf { get; set; }
        public bool ClienteAtivo { get; set; }
        public int ContatoId { get; set; }
        public int EnderecoId { get; set; }
    }
}
