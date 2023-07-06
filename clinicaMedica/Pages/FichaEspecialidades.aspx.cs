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
            if (Request.QueryString["mod"] != null)
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

                    byte mod;
                    if (byte.TryParse(Request.QueryString["mod"], out mod))
                    {
                        if (mod == 1) // VER
                        {
                            Especialidad_codigo.Enabled = false;
                            Especialidad_especialidad.Enabled = false;
                            AltaEspecialidad_agregar.Text = "Modificar";
                            AltaEspecialidad_cancelar.Text = "Volver";
                        }
                        if (mod == 2) //EDITAR
                        {
                            Especialidad_codigo.Enabled = true;
                            Especialidad_especialidad.Enabled = true;
                            AltaEspecialidad_agregar.Text = "Guardar";
                            AltaEspecialidad_cancelar.Text = "Cancelar";
                        }
                        if (mod == 3) //ELIMINAR
                        {
                            EspecialidadNegocio negocio = new EspecialidadNegocio();
                            negocio.eliminar(id);

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