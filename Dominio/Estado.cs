using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estado
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }

        public Estado() { }
        public Estado(int codigo, string nombre) 
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
    }
}
