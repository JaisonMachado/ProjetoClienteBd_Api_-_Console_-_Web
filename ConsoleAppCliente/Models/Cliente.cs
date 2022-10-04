using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCliente.Models
{
    public class Cliente
    {
        public Cliente()
        {
            
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }


        public override string ToString()
        {
            return string.Format($"ID: {ClienteId}\n Nome: {Nome}\n CPF: {Cpf}\n Ativo: {Ativo}");
        }

    }
}
