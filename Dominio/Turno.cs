using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int id { get; set; }
        public Usuario paciente { get; set; }
        public Usuario medico { get; set; }
        public DateTime fechaYHora { get; set; }
        public string observaciones { get; set; }
        public Estado estado { get; set; }
        public Usuario altaUsuario { get; set; }
        public Usuario modificacionUsuario { get; set; }
        public Usuario bajaUsuario { get; set; }
        public DateTime altaFecha { get; set; }
        public DateTime modificacionFecha { get; set; }
        public DateTime bajaFecha { get; set; }
        public Turno() 
        {
            paciente = new Usuario();
            medico = new Usuario();
            estado = new Estado();
            altaUsuario = new Usuario();
            modificacionUsuario = new Usuario();
            bajaUsuario = new Usuario();
        }
    }
}
