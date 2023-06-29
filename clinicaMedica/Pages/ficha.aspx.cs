using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Services.Description;

namespace clinicaMedica.Pages
{
    public partial class ficha : System.Web.UI.Page
    {
        RolNegocio Rol = new RolNegocio();
        EspecialidadNegocio Especialidad = new EspecialidadNegocio();
        LocalidadNegocio Loc = new LocalidadNegocio();
        ProvinciaNegocio pro = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            AltaUsuario_id.Enabled = false;
            
            if (!IsPostBack)
            {
                this.cargarBoxs();
            }
        }
        protected void cargarBoxs()
        {
            try
            {
                AltaUsuario_loc.DataSource = Loc.listar();
                AltaUsuario_loc.DataValueField = "id";
                AltaUsuario_loc.DataTextField = "localidad";
                AltaUsuario_loc.DataBind();
                AltaUsuario_loc.Items.Insert(0, new ListItem("Seleccionar localidad", ""));
                AltaUsuario_loc.Items.Add(new ListItem("Nueva localidad", "nuevo"));

                AltaUsuario_prov.DataSource = pro.listar();
                AltaUsuario_prov.DataValueField = "id";
                AltaUsuario_prov.DataTextField = "provincia";
                AltaUsuario_prov.DataBind();
                AltaUsuario_prov.Items.Insert(0, new ListItem("Seleccionar provincia", ""));

                ficha_rol.DataSource = Rol.listar();
                ficha_rol.DataValueField = "id";
                ficha_rol.DataTextField = "rol";
                ficha_rol.DataBind();
                ficha_rol.Items.Insert(0, new ListItem("Selecciona un rol", ""));

                ficha_esp.DataSource = Especialidad.listar();
                ficha_esp.DataValueField = "id";
                ficha_esp.DataTextField = "especialidad";
                ficha_esp.DataBind();
                ficha_esp.Items.Insert(0, new ListItem("Selecciona una especialidad", ""));
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void cargarUsuario(Usuario oUsuario)
        {
            oUsuario.codigoUsuario = AltaUsuario_codigo.Text;
            oUsuario.password = AltaUsuario_contra.Text;
            oUsuario.nombreYApellido = AltaUsuario_nombre.Text;
            oUsuario.emailUsuario = AltaUsuario_correo.Text;
            oUsuario.tipoDeDocumento = AltaUsuario_tipoDoc.Text;
            oUsuario.numeroDeDocumento = AltaUsuario_doc.Text;
            oUsuario.direccion = AltaUsuario_dire.Text;
            oUsuario.fechaDeNacimiento = AltaUsuario_fecNac.SelectedDate;

            oUsuario.localidad = new Localidad();
            oUsuario.localidad.id = short.Parse(AltaUsuario_loc.SelectedValue);
            oUsuario.rol = new Rol();
            oUsuario.rol.id = byte.Parse(ficha_rol.SelectedValue);
            oUsuario.especialidad = new Especialidad();
            oUsuario.especialidad.id = byte.Parse(ficha_esp.SelectedValue);

            oUsuario.altaUsuario = Session["usuario"].ToString();

        }
        protected void cargarLocalidad(Localidad oLoc)
        {
            oLoc.localidad = AltaUsuario_altaLoc.Text;
            oLoc.provincia = new Provincia();
            oLoc.provincia.id = byte.Parse(AltaUsuario_prov.SelectedValue);
        }

        protected void AltaUsuario_agregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            this.cargarUsuario(usuario);
            UsuarioNegocio negocio = new UsuarioNegocio();
            
            try
            {
                negocio.agregar(usuario);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void AltaUsuario_btnAgregar_loc_Click(object sender, EventArgs e)
        {
            Localidad loc = new Localidad();
            this.cargarLocalidad(loc);
            LocalidadNegocio negocio = new LocalidadNegocio();
            try
            {
                negocio.agregar(loc);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}