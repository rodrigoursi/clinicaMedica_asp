using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace clinicaMedica.Pages
{
    public partial class FichaRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    byte id;
                    if (byte.TryParse(Request.QueryString["id"], out id))
                    {
                        RolNegocio negocio = new RolNegocio();
                        List<Rol> lista = negocio.listar();
                        foreach (Rol rol in lista)
                        {
                            if (rol.id == id)
                            {
                                Rol_codigo.Text = rol.codigo;
                                Rol_rol.Text = rol.rol;
                                break; 
                            }
                        }
                    }
                }
            }
        }


        protected void AltaRoles_agregar_Click(object sender, EventArgs e)
        {

        }

        protected void AltaRoles_cancelar_Click(Object sender, EventArgs e) 
        {
            Response.Redirect("ABMRoles.aspx");
        }
    }
}