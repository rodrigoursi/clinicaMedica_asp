using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace clinicaMedica.Pages
{
    public partial class ficha : System.Web.UI.Page
    {
        RolNegocio Rol = new RolNegocio();
        EspacialidadNegocio Especialidad = new EspacialidadNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                ficha_rol.DataSource = Rol.listar();
                ficha_rol.DataValueField = "nombre";
                ficha_rol.DataBind();

                ficha_esp.DataSource = Especialidad.listar();
                ficha_esp.DataValueField = "nombre";
                ficha_esp.DataBind();
                
            }
        }
    }
}