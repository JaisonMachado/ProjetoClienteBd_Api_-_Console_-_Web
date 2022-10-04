using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientes.Entities
{
    public class ContatoCliente
    {
        public int Id { get; set; }
        public int Clientechave { get; set; }
        public string Telefone  {get; set;}
        public string Logradouro { get; set; }
        public string Bairro {get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
    }
}