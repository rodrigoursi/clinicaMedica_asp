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
    public partial class FichaEspecialidades : System.Web.UI.Page
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
                        EspecialidadNegocio negocio = new EspecialidadNegocio();
                        List<Especialidad> lista = negocio.listar();
                        foreach (Especialidad especialidad in lista)
                        {
                            if (especialidad.id == id)
                            {
                                Especialidad_codigo.Text = especialidad.codigo;
                                Especialidad_especialidad.Text = especialidad.especialidad;
                                break;
                            }
                        }
                    }
                }
            }
        }

        protected void AltaEspecialidad_agregar_Click(object sender, EventArgs e)
        {

        }

        protected void AltaEspecialidad_cancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ABMEspecialidades.aspx");
        }
    }
}