using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DiaSemana
    {
        public byte id { get; set; }
        public byte codDIa { get; set; }
        public string diaSemana { get; set; }
        public DiaSemana(byte codDIa, string diaSemana)
        {
            this.codDIa = codDIa;
            this.diaSemana = diaSemana;
        }
    }
}
