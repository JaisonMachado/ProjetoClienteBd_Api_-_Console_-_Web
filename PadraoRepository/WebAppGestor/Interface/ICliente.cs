using WebAppGestor.Models;

namespace WebAppGestor.Interface
{
    public interface ICliente 
    {
        public Cliente AddCliente(Cliente cliente);
        public List<Cliente> Listar();
        public Cliente ObterClientePorId(int id);
        public void UpdateCliente (Cliente cliente);
        public void RemoveCliente(int id);

        public Contato AddContato(Contato contato);
        public List<Contato> ListarContato();
        public Contato ObterContatoPorId(int id);
        public Contato ObterContatoPorIdCliente(int id);
        public void UpdateContato(Contato contato);
        public void RemoveContato(int id);


        public Endereco AddEndereco(Endereco endereco);
        public List<Endereco> ListarEndereco();
        public Endereco ObterEnderecoPorId(int id);
        public Endereco ObterEnderecoPorIdCliente (int id);
        public void UpdateEndereco(Endereco endereco);
        public void RemoveEndereco(int id);
    }
}
