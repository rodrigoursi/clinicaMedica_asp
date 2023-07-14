using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estado
    {
        public byte id { get; set; }
        public string codigo { get; set; }
        public string estado { get; set; }
        public bool defecto { get; set; }

        public Estado() { }
        public Estado(string codigo, string nombre) 
        {
            this.codigo = codigo;
            this.estado = nombre;
        }
    }
}
