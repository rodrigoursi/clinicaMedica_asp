using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmEstados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"];

            if (rolAux.permisosConfiguracion == false)
            {
                Response.Redirect("../default.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["mod"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        byte id;
                        if (byte.TryParse(Request.QueryString["id"], out id))
                        {
                            byte mod;
                            if (byte.TryParse(Request.QueryString["mod"], out mod))
                            {
                                if (mod == 3) //ELIMINAR
                                {
                                    EstadoNegocio negocio = new EstadoNegocio();
                                    negocio.eliminar(id);

                                }
                            }
                        }
                    }
                }
            }

            EstadoNegocio negocio2 = new EstadoNegocio();
            GridAbmEstados.DataSource = negocio2.listar();
            GridAbmEstados.DataBind();
        }
    }
}