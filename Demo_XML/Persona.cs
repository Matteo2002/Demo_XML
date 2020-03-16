using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_XML
{
    public class Persona
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public int Eta { get; set; }

        public DateTime DataNascita { get; set; }

        public override string ToString()
        {
            return $"{Nome} {Cognome}";
        }
    }
}
