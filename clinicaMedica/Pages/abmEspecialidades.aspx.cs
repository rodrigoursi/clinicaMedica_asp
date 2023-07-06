using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmEspecialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                                    EspecialidadNegocio negocio = new EspecialidadNegocio();
                                    negocio.eliminar(id);

                                }
                            }
                        }
                    }
                }
            }

            EspecialidadNegocio negocio2 = new EspecialidadNegocio();
            GridAbmEspecialidades.DataSource = negocio2.listar();
            GridAbmEspecialidades.DataBind();

        }
    }
}