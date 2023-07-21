using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class FichaEstado : System.Web.UI.Page
    {
        byte id;
        byte mod;
        Estado nuevoEstado = new Estado();
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
                            EstadoNegocio negocio = new EstadoNegocio();
                            List<Estado> lista = negocio.listar();
                            foreach (Estado estado in lista)
                            {
                                if (estado.id == id) // CARGA LOS DATOS DEL REGISTRO SELECCIONADO EN EL ABM
                                {
                                    Estados_codigo.Text = estado.codigo;
                                    Estados_estado.Text = estado.estado;
                                    Estados_defecto.Checked = estado.defecto;
                                    break;
                                }
                            }
                        }

                        if (byte.TryParse(Request.QueryString["mod"], out mod))
                        {
                            if (mod == 1) // VER
                            {
                                Estados_codigo.Enabled = false;
                                Estados_estado.Enabled = false;
                                Estados_defecto.Enabled = false;
                                Estado_agregar.Text = "Modificar";
                                Estado_cancelar.Text = "Volver";

                            }
                            if (mod == 2) //EDITAR
                            {
                                Estados_codigo.Enabled = true;
                                Estados_estado.Enabled = true;
                                Estados_defecto.Enabled = true;
                                Estado_agregar.Text = "Guardar";
                                Estado_cancelar.Text = "Cancelar";
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

        protected void Estado_agregar_Click(object sender, EventArgs e)
        {
            if(Estado_agregar.Text == "Modificar")   // RECARGA EN MODO EDICION
            {
                id = byte.Parse(Request.QueryString["id"]);
                Response.Redirect(("/Pages/FichaEstado.aspx?id=" + id + "&mod=2"));

            }
            if (byte.Parse(Request.QueryString["mod"]) == 0 && byte.Parse(Request.QueryString["id"]) == 0 )  // CONFIRMAR AGREGAR
            { 
                EstadoNegocio negocio = new EstadoNegocio();
                nuevoEstado.codigo = Estados_codigo.Text;
                nuevoEstado.estado = Estados_estado.Text;
                nuevoEstado.defecto = Estados_defecto.Checked;

                negocio.agregar(nuevoEstado);
            }

            if (byte.Parse(Request.QueryString["mod"]) == 2 && byte.Parse(Request.QueryString["id"]) != 0) // CONFIRMAR EDITAR
            {
                EstadoNegocio negocio = new EstadoNegocio();
                nuevoEstado.id = byte.Parse(Request.QueryString["id"]);
                nuevoEstado.codigo = Estados_codigo.Text;
                nuevoEstado.estado = Estados_estado.Text;
                nuevoEstado.defecto = Estados_defecto.Checked;

                negocio.editar(nuevoEstado);
            }
            Response.Redirect("ABMEstados.aspx");
        }


        protected void Estado_cancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ABMEstados.aspx");
        }
    }
}