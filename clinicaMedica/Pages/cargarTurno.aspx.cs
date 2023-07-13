using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace clinicaMedica.Pages
{
    public partial class cargarTurno : System.Web.UI.Page
    {
        private List<DiaSemana> diaSem = new List<DiaSemana>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DiaSemanaNegocio negDiaSem = new DiaSemanaNegocio();
            diaSem = negDiaSem.listar();
            if (!IsPostBack)
            {
                cargarBoxes();
            }
        }

        protected void buscarDoc_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negUser = new UsuarioNegocio();
            string filtro = $"numero_doc = {cargarTurno_documento.Text}";  
            List<Usuario> lista = new List<Usuario>();
            lista = negUser.buscarPor(filtro);
            cargarTurno_paciente.Text = lista[0].nombreYApellido;
        }
        protected void cargarBoxes()
        {
            EspecialidadNegocio negEsp = new EspecialidadNegocio();
            List<Especialidad> lista = negEsp.listar();
            cargaTurno_Esp.DataSource = lista;
            cargaTurno_Esp.DataValueField = "id";
            cargaTurno_Esp.DataTextField = "especialidad";
            cargaTurno_Esp.Items.Insert(0, new ListItem("Selecciona una especialidad", ""));
            cargaTurno_Esp.DataBind();

            cargaTurno_prof.Items.Insert(0, new ListItem("Selecciona un profesional", ""));
            cargaTurno_Esp.DataBind();
        }

        protected void cargaTurno_Esp_Changed(object sender, EventArgs e)
        {
            UsuarioNegocio negProf = new UsuarioNegocio();
            string filtro = $"especialidad = {cargaTurno_Esp.SelectedValue} AND bajaUsu IS NULL";
            List<Usuario> lista = negProf.buscarPor(filtro);
            cargaTurno_prof.DataSource = lista;
            cargaTurno_prof.DataValueField= "id";
            cargaTurno_prof.DataTextField = "nombreYApellido";
            cargaTurno_prof.Items.Insert(0, new ListItem("Selecciona un profesional", ""));
            cargaTurno_prof.DataBind();
        }

        protected void cargaTurno_prof_Changed(object sender, EventArgs e)
        {
            HorarioNegocio negHorario = new HorarioNegocio();

            string filtro = $"WHERE id_medico = {cargaTurno_prof.SelectedValue} ORDER BY id_medico";
            List<Horarios> listaHorarios = new List<Horarios>();
            listaHorarios = negHorario.listar(filtro);
            
            /*
            cargaTurno_fecha.DataSource = listaHorarios;
            cargaTurno_fecha.DataValueField = "id";
            cargaTurno_fecha.DataTextField = "idDia.id";
            cargaTurno_fecha.DataBind();*/
        }
    }
}