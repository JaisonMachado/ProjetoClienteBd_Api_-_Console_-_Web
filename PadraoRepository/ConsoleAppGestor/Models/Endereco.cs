namespace ConsoleAppGestor.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public bool EnderecoAtivo { get; set; }
        public int ClienteId { get; set; }

        public override string ToString()
        {
            return string.Format($"Cliente ID: {ClienteId} Endereço ID: {EnderecoId}  Endereço ativo: {EnderecoAtivo}\n " +
                $"Logradouro: {Logradouro}\n " +
                $"Bairro: {Bairro}  Cidade: {Cidade}");
        }
    }
}
