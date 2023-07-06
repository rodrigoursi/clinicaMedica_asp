using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace clinicaMedica
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string iniciarSesion { get; set; }
        public string abrirModal { get; set; }
        public List<Rol> roles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.iniciarSesion = Session["usuario"] == null ? "ENTRAR" : "SALIR";
            RolNegocio negocio = new RolNegocio();
            roles = negocio.listar();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            iniciarSesion = Session["usuario"] == null ? "ENTRAR" : "SALIR";
            abrirModal = Session["usuario"] == null ? "#modalLogin" : "#salirModal";
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("rol");
            Response.Redirect(Request.RawUrl);
        }
    }
}