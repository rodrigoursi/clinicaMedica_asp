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
        public string codigo { get; set; }
        public string rol { get; set; }
        public bool horariosSi { get; set; }
        public bool permisosConfiguracion { get; set; }
        public bool permisosFichas { get; set; }
        public bool permisosModificarTurno { get; set; }
        public bool permisosSoloTurnosPropios { get; set; }
        public Rol() { }
        public Rol(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.rol = nombre;
        }
    }
}
