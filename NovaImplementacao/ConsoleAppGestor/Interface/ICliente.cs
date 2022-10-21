using ConsoleAppGestor.Models;

namespace ConsoleAppGestor.Interface
{
    public interface ICliente 
    {
        public Cliente AddCliente(Cliente cliente);
        public List<Cliente> Listar();
        public Cliente ObterPorId(int id);
        public Cliente UpdateCliente (Cliente cliente);
        public void RemoveCliente(int id);
        public Cliente ObterPorNome(string nome);

        public Contato AddContato(Contato contato);
        public List<Contato> ListarContato();
        public Contato ObterContatoPorId(int id);
        public Contato ObterPorIdCliente(int id);
        public Contato UpdateContato(Contato contato);
        public void RemoveContato(int id);


        public Endereco AddEndereco(Endereco endereco);
        public List<Endereco> ListarEndereco();
        public Endereco ObterEnderecoPorId(int id);
        public Endereco ObterEnderecoPorIdCliente (int id);
        public Endereco UpdateEndereco(Endereco endereco);
        public void RemoveEndereco(int id);
    }
}
