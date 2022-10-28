namespace ConsoleAppGestor.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool ContatoAtivo { get; set; }
        public int ClienteId { get; set; }

        public override string ToString()
        {
            return string.Format($"Cliente ID: {ClienteId} Contato ID: {ContatoId}\n E-mail: {Email}\n Telefone: {Telefone}\n " +
                $"Contato ativo: {ContatoAtivo}");
        }
    }
}
