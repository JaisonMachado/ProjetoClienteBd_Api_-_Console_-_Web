using ApiClientes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Interface
{
    public interface IContatoCliente
    {
        public ContatoCliente GetByIdCliente  (int id);
        public void AddContatoCliente(ContatoCliente contato);
        public void UpdateContatoCliente(ContatoCliente contato);
    }
}