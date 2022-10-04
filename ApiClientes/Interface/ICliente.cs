using ApiClientes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Interface
{
    public interface ICliente
    {
        public Cliente GetById(int id);        
        public IEnumerable<Cliente> GetAll();
        public void AddCliente(Cliente cliente);
        public void UpdateCliente(Cliente cliente, int id);
        public void ExcluirCliente(int id);
    }
}