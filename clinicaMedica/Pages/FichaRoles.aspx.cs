using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace clinicaMedica.Pages
{
    public partial class FichaRoles : System.Web.UI.Page
    {
        byte id;
        byte mod;
        Rol nuevoRol = new Rol();
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
                            RolNegocio negocio = new RolNegocio();
                            List<Rol> lista = negocio.listar();
                            foreach (Rol rol in lista)
                            {
                                if (rol.id == id) // CARGA LOS DATOS DEL REGISTRO SELECCIONADO EN EL ABM
                                {
                                    Rol_codigo.Text = rol.codigo;
                                    Rol_rol.Text = rol.rol;
                                    horariosSi.Checked = rol.horariosSi;
                                    permisosConfiguracion.Checked = rol.permisosConfiguracion;
                                    permisosFichas.Checked = rol.permisosFichas;
                                    permisosModificarTurno.Checked = rol.permisosModificarTurno;
                                    permisosSoloTurnosPropios.Checked = rol.permisosSoloTurnosPropios;
                                    break;
                                }
                            }
                        }

                        if (byte.TryParse(Request.QueryString["mod"], out mod))
                        {
                            if (mod == 1) // VER
                            {
                                Rol_codigo.Enabled = false;
                                Rol_rol.Enabled = false;
                                horariosSi.Enabled = false;
                                permisosConfiguracion.Enabled = false;
                                permisosFichas.Enabled = false;
                                permisosModificarTurno.Enabled = false;
                                permisosSoloTurnosPropios.Enabled = false;
                                AltaRoles_agregar.Text = "Modificar";
                                AltaRol_cancelar.Text = "Volver";

                            }
                            if (mod == 2) //EDITAR
                            {
                                Rol_codigo.Enabled = true;
                                Rol_rol.Enabled = true;
                                horariosSi.Enabled = true;
                                permisosConfiguracion.Enabled = true;
                                permisosFichas.Enabled = true;
                                permisosModificarTurno.Enabled = true;
                                permisosSoloTurnosPropios.Enabled = true;
                                AltaRoles_agregar.Text = "Guardar";
                                AltaRol_cancelar.Text = "Cancelar";
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


        protected void AltaRoles_agregar_Click(object sender, EventArgs e)
        {
            if (AltaRoles_agregar.Text == "Modificar")   // RECARGA EN MODO EDICION
            {
                id = byte.Parse(Request.QueryString["id"]);
                Response.Redirect(("/Pages/FichaRoles.aspx?id=" + id + "&mod=2"));

            }
            if (byte.Parse(Request.QueryString["mod"]) == 0 && byte.Parse(Request.QueryString["id"]) == 0)  // CONFIRMAR AGREGAR
            {
                RolNegocio negocio = new RolNegocio();
                nuevoRol.codigo = Rol_codigo.Text;
                nuevoRol.rol = Rol_rol.Text;
                nuevoRol.horariosSi = horariosSi.Checked;
                nuevoRol.permisosConfiguracion = permisosConfiguracion.Checked;
                nuevoRol.permisosFichas = permisosFichas.Checked;
                nuevoRol.permisosModificarTurno = permisosModificarTurno.Checked;
                nuevoRol.permisosSoloTurnosPropios = permisosSoloTurnosPropios.Checked;

                negocio.agregar(nuevoRol);
            }

            if (byte.Parse(Request.QueryString["mod"]) == 2 && byte.Parse(Request.QueryString["id"]) != 0) // CONFIRMAR EDITAR
            {
                RolNegocio negocio = new RolNegocio();
                nuevoRol.id = byte.Parse(Request.QueryString["id"]);
                nuevoRol.codigo = Rol_codigo.Text;
                nuevoRol.rol = Rol_rol.Text;
                nuevoRol.horariosSi = horariosSi.Checked;
                nuevoRol.permisosConfiguracion = permisosConfiguracion.Checked;
                nuevoRol.permisosFichas = permisosFichas.Checked;
                nuevoRol.permisosModificarTurno = permisosModificarTurno.Checked;
                nuevoRol.permisosSoloTurnosPropios = permisosSoloTurnosPropios.Checked;

                negocio.editar(nuevoRol);
            }
            Response.Redirect("ABMRoles.aspx");
        }

        protected void AltaRoles_cancelar_Click(Object sender, EventArgs e) 
        {
            Response.Redirect("ABMRoles.aspx");
        }
    }
}