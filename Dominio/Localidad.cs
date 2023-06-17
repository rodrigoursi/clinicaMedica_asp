using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Localidad
    {
        public int id { get; set; }
        public Provincia provincia { get; set; }
        public string nombre { get; set; }
        public Localidad() { }
        public Localidad(Provincia provincia, string nombre)
        {
            this.provincia = provincia;
            this.nombre = nombre;
        }
    }
}
