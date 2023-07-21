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
using System.Security.Cryptography;
using System.Data.SqlTypes;


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
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            if (rolAux == null)
            {
                Response.Redirect("../default.aspx");
            }

            if (ficha_rol.SelectedValue == "" && Request.QueryString["rolId"] == null)
            {
                cargarHora = false;
            }
            else
            {
                validarRol();
            }
            dias = dSem.listar();
            AltaUsuario_id.Enabled = false;
            if (Request.QueryString["rolId"] != null && Request.QueryString["idEditar"] == null) ficha_rol.Enabled = false;

            if (!IsPostBack)
            {
                this.cargarBoxs();
            }
            if (Request.QueryString["idEditar"] != null)
            {
                validarRol();
            }
            if (Request.QueryString["id"] != null)
            {
                apagarComboBox();
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
                AltaUsuario_loc.Items.Add(new ListItem("Nueva localidad", "nuevo"));

                AltaUsuario_prov.DataSource = pro.listar();
                AltaUsuario_prov.DataValueField = "id";
                AltaUsuario_prov.DataTextField = "provincia";
                AltaUsuario_prov.DataBind();

                ficha_rol.DataSource = Rol.listar();
                ficha_rol.DataValueField = "id";
                ficha_rol.DataTextField = "rol";
                ficha_rol.DataBind();

                ficha_esp.DataSource = Especialidad.listar();
                ficha_esp.DataValueField = "id";
                ficha_esp.DataTextField = "especialidad";
                ficha_esp.DataBind();
                if (Request.QueryString["idEditar"] == null && Request.QueryString["id"] == null && Request.QueryString["idBorrar"] == null)
                {
                    AltaUsuario_loc.Items.Insert(0, new ListItem("Seleccionar localidad", ""));
                    
                    AltaUsuario_prov.Items.Insert(0, new ListItem("Seleccionar provincia", ""));

                    ficha_rol.Items.Insert(0, new ListItem("Selecciona un rol", ""));
                    if (Request.QueryString["rolId"] != null)
                    {
                        ficha_rol.SelectedValue = Request.QueryString["rolId"].ToString();
                    }

                    
                    ficha_esp.Items.Insert(0, new ListItem("Selecciona una especialidad", ""));

                    //listaHorarios.DataSource = dias;
                    //listaHorarios.DataBind();
                }
                listaHorarios.DataSource = dias;
                listaHorarios.DataBind();
                if (Request.QueryString["idEditar"] != null)
                {
                    Usuario usuario = new Usuario();
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    usuario = negocio.verUsuario(int.Parse(Request.QueryString["idEditar"]));
                    AltaUsuario_id.Text = usuario.id.ToString();
                    AltaUsuario_codigo.Text = usuario.codigoUsuario;
                    AltaUsuario_contra.Text = usuario.password;
                    AltaUsuario_repeat.Text = usuario.password;
                    AltaUsuario_nombre.Text = usuario.nombreYApellido;
                    AltaUsuario_correo.Text = usuario.emailUsuario;
                    AltaUsuario_tipoDoc.Text = usuario.tipoDeDocumento;
                    AltaUsuario_doc.Text = usuario.numeroDeDocumento;
                    AltaUsuario_dire.Text = usuario.direccion;
                    AltaUsuario_fecNac.Text = usuario.fechaDeNacimiento.ToShortDateString();
                    AltaUsuario_loc.SelectedValue = usuario.localidad.id.ToString();
                    ficha_rol.SelectedValue = usuario.rol.id.ToString();
                    //ficha_rol.Enabled = true; hacer esto aca es al pedo, porq cuando hacer un postback (agregar localidad nueva el enable se pierde)
                    ficha_esp.SelectedValue = usuario.especialidad.id.ToString();

                    List<Horarios> listaHoras = new List<Horarios>();
                    HorarioNegocio horario = new HorarioNegocio();
                    string filtro = "where id_medico = " + usuario.id.ToString();
                    listaHoras = horario.listar(filtro);
                    //listaHorarios.DataSource = listaHoras;
                    //listaHorarios.DataBind();
                    completarHorarios(listaHoras);
                }
                
            }
            catch (Exception ex)
            {
                //Session.Add("error", ex);
                //throw;
                Response.Redirect("/Pages/ErrorPage.aspx?errorMessage=" + Server.UrlEncode(ex.Message));

            }
        }
        protected void cargarUsuario(Usuario oUsuario)
        {
            try
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
            catch (Exception ex)
            {
                Response.Redirect("/Pages/ErrorPage.aspx?errorMessage=" + Server.UrlEncode(ex.Message));
            }

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
                lblAdvertencia.Text = "Por favor, complete los campos desplegabless";
                lblAdvertencia.Visible = true;
                return;  // aca pone un alert que diga q tiene desplegables sin seleccionar
            }
            if(!validarContra())
            {
                lblAdvertencia.Text = "las contraseñas no coinciden";
                lblAdvertencia.Visible = true;
                return; // aca pone un alert que diga q los campos de contraseña y repetir la contraseña tienen q ser iguales.
            }
            if(!validarCorreo())
            {
                lblAdvertencia.Text = "El campo EMAL debe ser un mail valido";
                lblAdvertencia.Visible = true;
                return; // aca pone un alert que diga q el campo correo electronico debe ser un mail valido.
            }

            if(!validarFecha())
            {
                lblAdvertencia.Text = "El campo FECHA DE NACIMIENTO debe ser una fecha validad con el formato DD/MM/AAAA";
                lblAdvertencia.Visible = true;
                return; // aca pone un alert que diga q el campo correo electronico debe ser un mail valido.
            }

            if (!validarDocumento())
            {
                lblAdvertencia.Text = "El campo NUMERO DE DOCUMENTO debe estar entre 0 y 999.9999.999";
                lblAdvertencia.Visible = true;
                return;
            }

            if(!validarTipoDocumento())
            {
                lblAdvertencia.Text = "El campo TIPO DE DOCUMENTO es erroneo, indicar DNI, CUIL, CUIT o PASAPORTE";
                lblAdvertencia.Visible = true;
                return;
            }

            Usuario usuario = new Usuario();
            this.cargarUsuario(usuario);
            UsuarioNegocio negocio = new UsuarioNegocio();
            
            try
            {
                if (Request.QueryString["idEditar"] == null) // aca si eliminar tiene pantalla hay q agregarlo en null
                {
                    int xId = negocio.cargarConId(usuario);
                    validarRol();
                    if (cargarHora)
                    {
                        this.cargarHorario(usuario, xId);
                    }
                }
                if (Request.QueryString["idEditar"] != null)
                {
                    usuario.id = int.Parse(Request.QueryString["idEditar"]);
                    int resulrado = negocio.editar(usuario, 2);
                    validarRol();
                    if (cargarHora)
                    {
                        
                        this.cargarHorario(usuario, usuario.id);
                    }
                }
                
            }
            catch (Exception ex)
            {
                //Session.Add("error", ex);
                //throw;
                Response.Redirect("/Pages/ErrorPage.aspx?errorMessage=" + Server.UrlEncode(ex.Message));
            }
            finally
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario creado correctamente!');", true);
                string rolId = Request.QueryString["rolId"];
                Response.Redirect("/pages/usuario.aspx?rolId=" + rolId);
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
                //Session.Add("error", ex);
                //throw;
                Response.Redirect("/Pages/ErrorPage.aspx?errorMessage=" + Server.UrlEncode(ex.Message));
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

        protected void volverUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx");
        }

        protected bool validarCampos()
        {
            if (AltaUsuario_loc.SelectedValue == "" || ficha_rol.SelectedValue == "" || ficha_esp.SelectedValue == "")
            {
                return false;
            }
            return true;
        }
        protected void cargarHorario(Usuario usuario, int id, int horarioId = 0)
        {
            int i = 0;
            foreach (RepeaterItem item in listaHorarios.Items)
            {
                System.Web.UI.WebControls.Label label_dia = (System.Web.UI.WebControls.Label)item.FindControl("lbl_dia");
                TextBox txtHIni = (TextBox)item.FindControl("AltaUsuario_hIni");
                TextBox txtHFin = (TextBox)item.FindControl("AltaUsuario_hFin");
                
                string dia = label_dia.Text;
                string horaInicio = txtHIni.Text;
                string horaFin = txtHFin.Text;
                if(horaInicio != "" && horaFin != "")
                {
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
                    if (Request.QueryString["idEditar"] != null)
                    {
                        List<Horarios> listaHoras = new List<Horarios>();
                        string filtro = "where id_medico = " + usuario.id.ToString();
                        listaHoras = horaNeg.listar(filtro);
                        if (listaHoras.Count() > i)
                        {
                            horario.id = listaHoras[i].id;
                            horaNeg.editar(horario);
                        }
                        else
                        {
                            horaNeg.agregar(horario);
                        }

                    }
                    else
                    {
                        horaNeg.agregar(horario);
                    }
                }
                
                i++;
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
            byte selecionado = Request.QueryString["rolId"] != null ? byte.Parse(Request.QueryString["rolId"]) : byte.Parse(ficha_rol.SelectedValue);
            List<byte> listaId = Rol.horariosSi();
            cargarHora = listaId.Exists(id => id == selecionado);
        }
        protected void completarHorarios(List<Horarios> listaHoras)
        {
            int i = 0;
            foreach (RepeaterItem dia in listaHorarios.Items)
            {

                foreach (var item in listaHoras)
                {
                    byte id = item.idDia.id;
                    if(id == dias[i].id)
                    {
                        TextBox textIni = (TextBox)dia.FindControl("AltaUsuario_hIni");
                        TextBox textFin = (TextBox)dia.FindControl("AltaUsuario_hFin");
                        textIni.Text = item.horaInicio.ToString("HH:mm");
                        textFin.Text = item.horaFin.ToString("HH:mm");
                    }
                }
                i++;
            }
        }
        protected void apagarComboBox()
        {
            AltaUsuario_codigo.Enabled = false;
            AltaUsuario_contra.Enabled = false;
            AltaUsuario_repeat.Enabled = false;
            AltaUsuario_nombre.Enabled = false;
            AltaUsuario_correo.Enabled = false;
            AltaUsuario_tipoDoc.Enabled = false;
            AltaUsuario_doc.Enabled = false;
            AltaUsuario_dire.Enabled = false;
            AltaUsuario_loc.Enabled = false;
            AltaUsuario_fecNac.Enabled = false;
            ficha_rol.Enabled = false;
            ficha_esp.Enabled = false;
            AltaUsuario_agregar.Visible = false;

            foreach (RepeaterItem item in listaHorarios.Items)
            {
                TextBox AltaUsuario_hIni = (TextBox)item.FindControl("AltaUsuario_hIni");
                TextBox AltaUsuario_hFin = (TextBox)item.FindControl("AltaUsuario_hFin");
                AltaUsuario_hIni.Enabled = false;
                AltaUsuario_hFin.Enabled = false;
            }
            panelHorarios.Update();
        }
        protected bool validarContra()
        {
            string contra = AltaUsuario_contra.Text;
            string repetir = AltaUsuario_repeat.Text;
            if(contra == repetir)
            {
                return true;
            }
            return false;
        }
        protected bool validarCorreo()
        {
            int con = 0;
            string correo = AltaUsuario_correo.Text;
            foreach (char letra in correo)
            {
                if (letra == '@')
                {
                    con++;
                }
            }
            if(con == 1) return true;
            return false;
        }

        protected bool validarFecha()
        {
            string inputFecha = AltaUsuario_fecNac.Text;
            DateTime fecha;

            if (DateTime.TryParse(inputFecha, out fecha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool validarDocumento()
        {
            int numDoc;
            if (int.TryParse(AltaUsuario_doc.Text, out numDoc))
            {
                if (numDoc > 0 && numDoc < 999999999)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                return false; 
            }
        }

        protected bool validarTipoDocumento()
        {
            string tipoDoc = AltaUsuario_tipoDoc.Text.ToUpper();

            if (tipoDoc == "DNI" || tipoDoc == "CUIL" || tipoDoc == "CUIT" || tipoDoc == "PASAPORTE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}