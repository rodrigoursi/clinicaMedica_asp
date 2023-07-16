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
        byte id;
        byte mod;
        Especialidad nuevaEspecialidad = new Especialidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rol rolAux = new Rol();
                rolAux = (Rol)Session["currentRol"];

                if (rolAux.permisosConfiguracion == false)
                {
                    Response.Redirect("../default.aspx");
                }

                if (Request.QueryString["mod"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        if (byte.TryParse(Request.QueryString["id"], out id))
                        {
                            EspecialidadNegocio negocio = new EspecialidadNegocio();
                            List<Especialidad> lista = negocio.listar();
                            foreach (Especialidad especialidad in lista)
                            {
                                if (especialidad.id == id) // CARGA LOS DATOS DEL REGISTRO SELECCIONADO EN EL ABM
                                {
                                    Especialidad_codigo.Text = especialidad.codigo;
                                    Especialidad_especialidad.Text = especialidad.especialidad;
                                    break;
                                }
                            }
                        }

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
                                EstadoNegocio negocio = new EstadoNegocio();
                                negocio.eliminar(id);

                            }
                        }
                    }
                }
            }
        }

        protected void AltaEspecialidad_agregar_Click(object sender, EventArgs e)
        {
            if (AltaEspecialidad_agregar.Text == "Modificar")   // RECARGA EN MODO EDICION
            {
                id = byte.Parse(Request.QueryString["id"]);
                Response.Redirect(("/Pages/FichaEspecialidades.aspx?id=" + id + "&mod=2"));

            }
            if (byte.Parse(Request.QueryString["mod"]) == 0 && byte.Parse(Request.QueryString["id"]) == 0)  // CONFIRMAR AGREGAR
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                nuevaEspecialidad.codigo = Especialidad_codigo.Text;
                nuevaEspecialidad.especialidad = Especialidad_especialidad.Text;

                negocio.agregar(nuevaEspecialidad);
            }

            if (byte.Parse(Request.QueryString["mod"]) == 2 && byte.Parse(Request.QueryString["id"]) != 0) // CONFIRMAR EDITAR
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                nuevaEspecialidad.id = byte.Parse(Request.QueryString["id"]);
                nuevaEspecialidad.codigo = Especialidad_codigo.Text;
                nuevaEspecialidad.especialidad = Especialidad_especialidad.Text;

                negocio.editar(nuevaEspecialidad);
            }
            Response.Redirect("ABMEspecialidades.aspx");
        }

        protected void AltaEspecialidad_cancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ABMEspecialidades.aspx");
        }
    }
}