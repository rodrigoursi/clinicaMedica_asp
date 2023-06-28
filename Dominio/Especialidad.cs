using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Especialidad
    {
        public short id { get; set; }
        public short codigo { get; set; }
        public string especialidad { get; set; }
        public Especialidad() { }
        public Especialidad(short codigo, string nombre)
        {
            this.codigo = codigo;
            this.especialidad = nombre;
        }
    }
}
