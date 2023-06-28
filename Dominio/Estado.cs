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
        public byte codigo { get; set; }
        public string estado { get; set; }

        public Estado() { }
        public Estado(byte codigo, string nombre) 
        {
            this.codigo = codigo;
            this.estado = nombre;
        }
    }
}
