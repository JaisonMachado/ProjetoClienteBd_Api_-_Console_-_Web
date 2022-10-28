namespace ConsoleAppGestor.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string Cpf { get; set; }
        public bool ClienteAtivo { get; set; }
        public int ContatoId { get; set; }
        public int EnderecoId { get; set; }

        public override string ToString()
        {
            return string.Format($"ID: {ClienteId}\n Nome: {ClienteNome}\n CPF: {Cpf}\n Ativo: {ClienteAtivo}\n " +
                $"Contato Id: {ContatoId}  Endereço Id: {EnderecoId}");
        }
    }

}
