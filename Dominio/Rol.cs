using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Rol
    {
        public byte id { get; set; }
        public byte codigo { get; set; }
        public string rol { get; set; }
        public Rol() { }
        public Rol(byte codigo, string nombre)
        {
            this.codigo = codigo;
            this.rol = nombre;
        }
    }
}
