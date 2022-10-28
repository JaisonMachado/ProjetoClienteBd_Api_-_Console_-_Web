using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGestor.Models
{
    public class Detalhes
    {
        public Cliente Cliente { get; set; }
        public Contato Contato { get; set; }
        public Endereco Endereco { get; set; }
    }
}
