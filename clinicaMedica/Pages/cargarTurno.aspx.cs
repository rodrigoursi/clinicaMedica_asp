using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using Dominio;
using Negocio;

namespace clinicaMedica.Pages
{
    public partial class cargarTurno : System.Web.UI.Page
    {
        private List<DiaSemana> diaSem = new List<DiaSemana>();
        List<Horarios> listaHorarios = new List<Horarios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cargaTurno_prof.SelectedValue != "")
            {
                HorarioNegocio negHorario = new HorarioNegocio();
                string filtro = $"WHERE id_medico = {cargaTurno_prof.SelectedValue} ORDER BY id_medico";

                listaHorarios = negHorario.listar(filtro);
            }
            
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
            cargarTurno_paciente.Attributes["value"] = lista[0].id.ToString();
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
            cargaTurno_prof.DataBind();

            cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));
            cargaTurno_fecha.DataBind();
            cargaTurno_hora.Items.Insert(0, new ListItem("Selecciona un horario", ""));
            cargaTurno_hora.DataBind();
        }

        protected void cargaTurno_Esp_Changed(object sender, EventArgs e)
        {
            UsuarioNegocio negProf = new UsuarioNegocio();
            string filtro = $"especialidad = {cargaTurno_Esp.SelectedValue} AND bajaUsu IS NULL";
            List<Usuario> lista = negProf.buscarPor(filtro);
            cargaTurno_prof.DataSource = lista;
            cargaTurno_prof.DataValueField= "id";
            cargaTurno_prof.DataTextField = "nombreYApellido";
            
            cargaTurno_prof.DataBind();
            cargaTurno_prof.Items.Insert(0, new ListItem("Selecciona un profesional", ""));
        }

        protected void cargaTurno_prof_Changed(object sender, EventArgs e)
        {
            //HorarioNegocio negHorario = new HorarioNegocio();
            //string filtro = $"WHERE id_medico = {cargaTurno_prof.SelectedValue} ORDER BY id_medico";
            //List<Horarios> listaHorarios = new List<Horarios>();
            //listaHorarios = negHorario.listar(filtro);
            DiaSemana oDia = new DiaSemana();
            oDia = diaSem.Find(x => x.id == listaHorarios[0].idDia.id);
            int dia = (int)oDia.codDia;
            List<DateTime> fechas = devolverProximaFecha((DayOfWeek)dia, 3);
            List<ListItem> horarios = new List<ListItem>();
            fechas.ForEach(x =>
            {
                //cargaTurno_fecha.Items.Add(new ListItem(x.ToString("dd/MM/yyyy"), dia.ToString()));
                horarios.Add(new ListItem(x.ToString("dd/MM/yyyy"), dia.ToString()));
            });
            cargaTurno_fecha.DataSource = horarios;
            cargaTurno_fecha.DataBind();
            cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));
            
        }
        protected void cargaTurno_fecha_changed(object sender, EventArgs e)
        {
            List<string> lsHoras = devolverHorarios();
            cargaTurno_hora.DataSource = lsHoras;
            cargaTurno_hora.DataBind();
            cargaTurno_hora.Items.Insert(0, new ListItem("Selecciona un horario", ""));
            /*lsHoras.ForEach(x =>
            {
                cargaTurno_hora.Items.Add(new ListItem(listaHorarios[0].horaInicio.ToString("H:mm:ss"), listaHorarios[0].id.ToString()));
            });*/

            //cargaTurno_hora.Items.Add(new ListItem("prueba", "0"));

        }
        protected List<DateTime> devolverProximaFecha(DayOfWeek diaObjetivo, int cantidad)
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Today;

            // Obtener el día de la semana actual
            DayOfWeek diaSemana = fechaActual.DayOfWeek;

            // Calcular la cantidad de días hasta el próximo día objetivo
            int diasHastaObjetivo = ((int)diaObjetivo - (int)diaSemana + 7) % 7;

            // Calcular las próximas fechas objetivo
            List<DateTime> proximasFechasObjetivo = new List<DateTime>();

            for (int i = 0; i < cantidad; i++)
            {
                DateTime proximaFechaObjetivo = fechaActual.AddDays(diasHastaObjetivo + (7 * i));
                proximasFechasObjetivo.Add(proximaFechaObjetivo);
            }

            return proximasFechasObjetivo;
        }
        protected List<string> devolverHorarios()
        {
            List<string> lista = new List<string>();
            lista.Add(listaHorarios[0].horaInicio.ToString("HH:mm:ss"));
            DateTime horaActual = listaHorarios[0].horaInicio;
            while (horaActual < listaHorarios[0].horaFin)
            {
                horaActual = horaActual.AddHours(1);
                if(horaActual != listaHorarios[0].horaFin)
                    lista.Add(horaActual.ToString("HH:mm:ss"));
            }
            return lista;
        }

        protected void grabarTurno_Click(object sender, EventArgs e)
        {
            Turno objTurno = new Turno();
            cargar(objTurno);
            TunoNegocio turno = new TunoNegocio();
            turno.agregar(objTurno);
        }
        protected void cargar(Turno obj)
        {
            EstadoNegocio negEstado = new EstadoNegocio();
            List<Estado> objEstado = negEstado.listar();
            string fecha = cargaTurno_fecha.Text;
            string hora = cargaTurno_hora.Text;
            DateTime fechaYhora = DateTime.Parse(fecha + " " + hora);
            Usuario objUser = new Usuario();
            objUser.id = int.Parse(cargarTurno_paciente.Attributes["value"]);
            obj.paciente = objUser;
            objUser.id = int.Parse(cargaTurno_prof.SelectedValue);
            obj.medico = objUser;
            obj.fechaYHora = fechaYhora;
            obj.observaciones = cargarTurno_mot.Text;
            obj.estado = objEstado.Find(x => x.defecto);
        }
    }
}