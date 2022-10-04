using ApiClientes.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ApiClientes.Context
{
    public class ClienteContext : DbContext 
    {
        
    
        public ClienteContext (DbContextOptions<ClienteContext>options): base(options)
        {

        }
        
        public DbSet<Cliente> TabelaClientes { get; set; }
        public DbSet<ContatoCliente> TabelaContatos { get; set; }
        
    }
    
}