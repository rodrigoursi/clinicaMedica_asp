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
            EstadoNegocio negocio = new EstadoNegocio();
            GridAbmEstados.DataSource = negocio.listar();
            GridAbmEstados.DataBind();
        }
    }
}