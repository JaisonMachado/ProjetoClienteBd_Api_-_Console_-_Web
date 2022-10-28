using WebAppGestor.Models;

namespace WebAppGestor.Interface
{
    public interface IContato
    {
        public Contato AddContato (Contato contato);
        public List<Contato> Listar();
        public Contato ObterPorId(int id);
        public Contato ObterPorIdCliente (int id);
    }
}
