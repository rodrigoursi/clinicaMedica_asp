using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Services.Description;
using System.Reflection.Emit;

namespace clinicaMedica.Pages
{
    public partial class ficha : System.Web.UI.Page
    {
        RolNegocio Rol = new RolNegocio();
        EspecialidadNegocio Especialidad = new EspecialidadNegocio();
        LocalidadNegocio Loc = new LocalidadNegocio();
        ProvinciaNegocio pro = new ProvinciaNegocio();
        DiaSemanaNegocio dSem = new DiaSemanaNegocio();
        List<DiaSemana> dias = new List<DiaSemana>();
        public bool cargarHora { get; set; }
        public int id { get; set; }
        public String dia { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ficha_rol.SelectedValue == "")
            {
                cargarHora = false;
            }
            else
            {
                validarRol();
            }
            dias = dSem.listar();
            AltaUsuario_id.Enabled = false;
            if (Request.QueryString["rolId"] != null) ficha_rol.Enabled = false;
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
                if (Request.QueryString["rolId"] != null)
                {
                    ficha_rol.SelectedValue = Request.QueryString["rolId"].ToString();
                }

                ficha_esp.DataSource = Especialidad.listar();
                ficha_esp.DataValueField = "id";
                ficha_esp.DataTextField = "especialidad";
                ficha_esp.DataBind();
                ficha_esp.Items.Insert(0, new ListItem("Selecciona una especialidad", ""));

                listaHorarios.DataSource = dias;
                listaHorarios.DataBind();
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
            oUsuario.fechaDeNacimiento = DateTime.Parse(AltaUsuario_fecNac.Text);

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
            if(!this.validarCampos())
            {
                return;
            }
            Usuario usuario = new Usuario();
            this.cargarUsuario(usuario);
            UsuarioNegocio negocio = new UsuarioNegocio();
            
            try
            {
                int xId = negocio.cargarConId(usuario);
                validarRol();
                if (cargarHora)
                {
                    this.cargarHorario(usuario, xId);
                }
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
            if (loc.localidad == "") return;
            try
            {
                negocio.agregar(loc);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
            finally
            {
                AltaUsuario_loc.DataSource = Loc.listar();
                AltaUsuario_loc.DataValueField = "id";
                AltaUsuario_loc.DataTextField = "localidad";
                AltaUsuario_loc.DataBind();
                AltaUsuario_loc.Items.Insert(0, new ListItem("Seleccionar localidad", ""));
                AltaUsuario_loc.Items.Add(new ListItem("Nueva localidad", "nuevo"));
            }
        }

        protected bool validarCampos()
        {
            if (AltaUsuario_loc.SelectedValue == "" || ficha_rol.SelectedValue == "" || ficha_esp.SelectedValue == "")
            {
                return false;
            }
            return true;
        }
        protected void cargarHorario(Usuario usuario, int id)
        {
            foreach (RepeaterItem item in listaHorarios.Items)
            {
                System.Web.UI.WebControls.Label label_dia = (System.Web.UI.WebControls.Label)item.FindControl("lbl_dia");
                TextBox txtHIni = (TextBox)item.FindControl("AltaUsuario_hIni");
                TextBox txtHFin = (TextBox)item.FindControl("AltaUsuario_hFin");
                //int id = dias[indice].id;
                string dia = label_dia.Text;
                string horaInicio = txtHIni.Text;
                string horaFin = txtHFin.Text;
                DateTime horaI = DateTime.Parse(horaInicio);
                DateTime horaF = DateTime.Parse(horaFin);
                Horarios horario = new Horarios();
                horario.horaInicio = horaI;
                horario.horaFin = horaF;
                DiaSemana idDia = dias.Find(x => x.diaSemana == dia);
                horario.idDia = idDia;
                usuario.id = id;
                horario.idMedico = usuario;
                HorarioNegocio horaNeg = new HorarioNegocio();
                horaNeg.agregar(horario);

            }
            return;
        }

        protected void ficha_rol_SelectChanged(object sender, EventArgs e)
        {
            if(ficha_rol.SelectedValue == "") 
            { 
                cargarHora = false;
            } else
            {
                validarRol();
            }
        }

        protected void validarRol()
        {
            byte selecionado = byte.Parse(ficha_rol.SelectedValue);
            List<byte> listaId = Rol.horariosSi();
            cargarHora = listaId.Exists(id => id == selecionado);
        }
    }
}