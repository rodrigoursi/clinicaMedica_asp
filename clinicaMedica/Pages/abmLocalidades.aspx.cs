using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmLocalidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LocalidadNegocio negocio = new LocalidadNegocio();
            GridAbmLocalidades.DataSource = negocio.listar();
            GridAbmLocalidades.DataBind();
        }
    }
}