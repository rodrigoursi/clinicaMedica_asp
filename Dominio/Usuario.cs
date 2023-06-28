using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int id { get; set; }
        public int codigoUsuario { get; set; }
        public string password { get; set; }
        public string nombreYApellido { get; set; }
        public string emailUsuario { get; set; }
        public string tipoDeDocumento { get; set; }
        public string numeroDeDocumento { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public string direccion { get; set; }
        public Localidad localidad { get; set; }
        public Especialidad especialidad { get; set; }
        public Rol rol { get; set; }
        public int altaUsuario { get; set; }
        public int modificacionUsuario {get; set;}
        public int bajaUsuario { get; set; }
        public DateTime altaFecha { get; set; }
        public DateTime modificacionFecha { get; set; }
        public DateTime bajaFecha { get; set; }            
        public Usuario() { }
        public Usuario(int codigo, string nombreCompleto)
        {
            this.codigoUsuario = codigo;
            this.nombreYApellido = nombreCompleto;
        }
    }
}
