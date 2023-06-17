using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Especialidad
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public Especialidad() { }
        public Especialidad(int codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
    }
}
