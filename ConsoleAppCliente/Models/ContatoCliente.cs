using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCliente.Models
{
    public class ContatoCliente
    {
        public int Id { get; set; }
        public int Clientechave { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format($"Contato ID: {Id}\n Telefone: {Telefone}\n E-mail: {Email}" +
                $"Logradouro: {Logradouro}, Bairro: {Bairro}, Cidade: {Cidade}");
        }
    }
}
