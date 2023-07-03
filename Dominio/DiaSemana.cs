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
        public byte codDia { get; set; }
        public string diaSemana { get; set; }
        public DiaSemana() { }

        public DiaSemana(byte codDia, string diaSemana)
        {
            this.codDia = codDia;
            this.diaSemana = diaSemana;
        }
    }
}
