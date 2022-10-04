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
    public class RepositoryContato : IContatoCliente
    {
        private readonly ClienteContext _context;

        public RepositoryContato(ClienteContext clienteContext) => this._context = clienteContext;
        public void AddContatoCliente (ContatoCliente contato)
        {
            _context.TabelaContatos.Add(contato);
        }

        public ContatoCliente GetByIdCliente (int id)=> _context.TabelaContatos.SingleOrDefault(c => c.Clientechave == id);
        

        public void UpdateContatoCliente(ContatoCliente contato)
        {
           
            _context.Entry(contato).State = EntityState.Modified;
            _context.SaveChanges();
        }

       
    }
}