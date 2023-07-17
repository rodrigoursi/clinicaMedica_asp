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
    public partial class FichaLocalidades : System.Web.UI.Page
    {
        byte id;
        byte mod;
        Localidad nuevaLocalidad = new Localidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rol rolAux = new Rol();
                rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

                if (rolAux == null || rolAux.permisosConfiguracion == false)
                {
                    Response.Redirect("../default.aspx");
                }

                if (Request.QueryString["mod"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        if (byte.TryParse(Request.QueryString["id"], out id))
                        {
                            LocalidadNegocio negocio = new LocalidadNegocio();
                            List<Localidad> lista = negocio.listar();
                            foreach (Localidad localidad in lista)
                            {
                                if (localidad.id == id) // CARGA LOS DATOS DEL REGISTRO SELECCIONADO EN EL ABM
                                {
                                    Localidad_localidad.Text = localidad.localidad;
                                    Localidad_provincia.Text = localidad.provincia.provincia;
                                    break;
                                }
                            }
                        }

                        if (byte.TryParse(Request.QueryString["mod"], out mod))
                        {
                            if (mod == 1) // VER
                            {
                                Localidad_localidad.Enabled = false;
                                Localidad_provincia.Enabled = false;
                                Localidad_agregar.Text = "Modificar";
                                Localidad_cancelar.Text = "Volver";

                            }
                            if (mod == 2) //EDITAR
                            {
                                Localidad_localidad.Enabled = true;
                                Localidad_provincia.Enabled = true;
                                Localidad_agregar.Text = "Guardar";
                                Localidad_cancelar.Text = "Cancelar";
                            }
                            if (mod == 3) //ELIMINAR
                            {
                                LocalidadNegocio negocio = new LocalidadNegocio();
                                negocio.eliminar(id);

                            }
                        }
                    }
                }
            }
        }

        protected void Localidad_agregar_Click(object sender, EventArgs e)
        {
            if (Localidad_agregar.Text == "Modificar")   // RECARGA EN MODO EDICION
            {
                id = byte.Parse(Request.QueryString["id"]);
                Response.Redirect(("/Pages/FichaLocalidades.aspx?id=" + id + "&mod=2"));

            }
            if (byte.Parse(Request.QueryString["mod"]) == 0 && byte.Parse(Request.QueryString["id"]) == 0)  // CONFIRMAR AGREGAR
            {
                LocalidadNegocio negocio = new LocalidadNegocio();
                nuevaLocalidad.localidad = Localidad_localidad.Text;
                nuevaLocalidad.provincia.provincia = Localidad_provincia.Text;

                negocio.agregar(nuevaLocalidad);
            }

            if (byte.Parse(Request.QueryString["mod"]) == 2 && byte.Parse(Request.QueryString["id"]) != 0) // CONFIRMAR EDITAR
            {
                LocalidadNegocio negocio = new LocalidadNegocio();
                nuevaLocalidad.id = byte.Parse(Request.QueryString["id"]);
                nuevaLocalidad.localidad = Localidad_localidad.Text;
                nuevaLocalidad.provincia.provincia = Localidad_provincia.Text;

                negocio.editar(nuevaLocalidad);
            }
            Response.Redirect("ABMLocalidades.aspx");
        }


        protected void Localidad_cancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ABMLocalidades.aspx");
        }
    }
}