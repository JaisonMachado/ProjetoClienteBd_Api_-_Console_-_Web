using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class ClienteContext:DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options):base(options)
        {

        }
        public DbSet<Cliente> TabelaCliente { get; set; }
        public DbSet<Endereco> TabelaEnderecoCliente { get; set; }
        public DbSet<Contato> TabelaContatoCliente { get; set; }
    }
}
