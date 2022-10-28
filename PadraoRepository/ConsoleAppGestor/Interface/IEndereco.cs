using ConsoleAppGestor.Models;

namespace ConsoleAppGestor.Interface
{
    public interface IEndereco
    {
        
        public Endereco AddEndereco (Endereco endereco);
        public List<Endereco> Listar();
        public Endereco ObterPorId(int id);
        public Endereco ObterPorIdCliente(int id);
    }
}
