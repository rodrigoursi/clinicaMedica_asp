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
        byte id = 0;
        byte mod = 0;
        Estado nuevoEstado = new Estado();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                            if (estado.id == id)
                            {
                                Estados_codigo.Text = estado.codigo;
                                Estados_estado.Text = estado.estado;
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
            if(mod==0 && id==0 )  // CONFIRMAR AGREGAR
            { 
                EstadoNegocio negocio = new EstadoNegocio();
                nuevoEstado.codigo = Estados_codigo.Text;
                nuevoEstado.estado = Estados_estado.Text;

                negocio.agregar(nuevoEstado);
            }

            if (mod == 2 && id != 0) // CONFIRMAR EDITAR
            {
                EstadoNegocio negocio = new EstadoNegocio();
                nuevoEstado.id = id;
                nuevoEstado.codigo = Estados_codigo.Text;
                nuevoEstado.estado = Estados_estado.Text;

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