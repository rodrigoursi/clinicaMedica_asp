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
    public partial class FichaProvincias : System.Web.UI.Page
    {
        byte id;
        byte mod;
        Provincia nuevaProvincia = new Provincia();
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
                            ProvinciaNegocio negocio = new ProvinciaNegocio();
                            List<Provincia> lista = negocio.listar();
                            foreach (Provincia provincia in lista)
                            {
                                if (provincia.id == id) // CARGA LOS DATOS DEL REGISTRO SELECCIONADO EN EL ABM
                                {
                                    Provincias_provincia.Text = provincia.provincia;
                                    break;
                                }
                            }
                        }

                        if (byte.TryParse(Request.QueryString["mod"], out mod))
                        {
                            if (mod == 1) // VER
                            {
                                Provincias_provincia.Enabled = false;
                                Provincia_agregar.Text = "Modificar";
                                Provincia_cancelar.Text = "Volver";

                            }
                            if (mod == 2) //EDITAR
                            {
                                Provincias_provincia.Enabled = true;
                                Provincia_agregar.Text = "Guardar";
                                Provincia_cancelar.Text = "Cancelar";
                            }
                            if (mod == 3) //ELIMINAR
                            {
                                ProvinciaNegocio negocio = new ProvinciaNegocio();
                                negocio.eliminar(id);

                            }
                        }
                    }
                }
            }
        }

        protected void Provincia_agregar_Click(object sender, EventArgs e)
        {
            if (Provincia_agregar.Text == "Modificar")   // RECARGA EN MODO EDICION
            {
                id = byte.Parse(Request.QueryString["id"]);
                Response.Redirect(("/Pages/FichaProvincias.aspx?id=" + id + "&mod=2"));

            }
            if (byte.Parse(Request.QueryString["mod"]) == 0 && byte.Parse(Request.QueryString["id"]) == 0)  // CONFIRMAR AGREGAR
            {
                ProvinciaNegocio negocio = new ProvinciaNegocio();
                nuevaProvincia.provincia = Provincias_provincia.Text;

                negocio.agregar(nuevaProvincia);
            }

            if (byte.Parse(Request.QueryString["mod"]) == 2 && byte.Parse(Request.QueryString["id"]) != 0) // CONFIRMAR EDITAR
            {
                ProvinciaNegocio negocio = new ProvinciaNegocio();
                nuevaProvincia.id = byte.Parse(Request.QueryString["id"]);
                nuevaProvincia.provincia = Provincias_provincia.Text;

                negocio.editar(nuevaProvincia);
            }
            Response.Redirect("ABMProvincias.aspx");
        }


        protected void Provincia_cancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ABMProvincias.aspx");
        }
    }
}