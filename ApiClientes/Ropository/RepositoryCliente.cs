using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClientes.Context;
using ApiClientes.Entities;
using ApiClientes.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Ropository
{
    public class RepositoryCliente : ICliente
    {
       private readonly ClienteContext _context;

       public RepositoryCliente(ClienteContext clienteContext)=>this._context=clienteContext;

       

        public void AddCliente(Cliente cliente)
        {
            _context.TabelaClientes.Add(cliente);
        }

       

        public void ExcluirCliente(int id)
        {
            var clienteBd=_context.TabelaClientes.SingleOrDefaultAsync(c => c.ClienteId == id).Result;

            clienteBd.Ativo = false;
            _context.Entry(clienteBd).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll()=>_context.TabelaClientes.ToListAsync().Result;
             
        public int GetId()
        {
            var clientesLista= _context.TabelaClientes.ToListAsync().Result;
            int ultimoId=0;
            foreach(var item in clientesLista)
            {
                ultimoId=item.ClienteId;
            }
            return ultimoId;
        }

        public Cliente GetById(int id)=>_context.TabelaClientes.SingleOrDefaultAsync(c => c.ClienteId == id).Result;
        
        
        public void UpdateCliente(Cliente cliente,int id)
        {            
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}