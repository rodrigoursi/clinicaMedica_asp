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
    public partial class FichaEstado : System.Web.UI.Page
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
                        EstadoNegocio negocio = new EstadoNegocio();
                        List<Estado> lista = negocio.listar();
                        foreach (Estado estado in lista)
                        {
                            if (estado.id == id)
                            {
                                Estados_codigo.Text = estado.codigo;
                                Estados_estado.Text = estado.estado;
                                break;
                            }
                        }
                    }

                    byte mod;
                    if (byte.TryParse(Request.QueryString["mod"], out mod))
                    {
                        if (mod == 1) // VER
                        {
                            Estados_codigo.Enabled = false;
                            Estados_estado.Enabled = false;
                            Estado_agregar.Text = "Modificar";
                            Estado_cancelar.Text = "Volver";
                        }
                        if (mod == 2) //EDITAR
                        {
                            Estados_codigo.Enabled = true;
                            Estados_estado.Enabled = true;
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


        protected void Estado_agregar_Click(object sender, EventArgs e)
        {

        }

        protected void Estado_cancelar_Click(Object sender, EventArgs e)
        {
            Response.Redirect("ABMRoles.aspx");
        }
    }
}