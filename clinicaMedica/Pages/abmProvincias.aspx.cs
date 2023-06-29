using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmProvincias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();
            GridAbmProvincias.DataSource = negocio.listar();
            GridAbmProvincias.DataBind();
        }
    }
}