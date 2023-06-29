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
            int altaUsuario = 1;
            //String altaUsuario = Session["usuario"].ToString();
            //oUsuario.altaUsuario = Convert.ToInt32(altaUsuario);

        }

        protected void AltaUsuario_agregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            this.cargarUsuario(usuario);
            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.agregar(usuario);
        }
    }
}