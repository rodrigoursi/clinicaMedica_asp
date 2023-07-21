using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private List<Horarios> listaHorarios = new List<Horarios>();
        private TunoNegocio turno = new TunoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            if (rolAux == null)
            {
                Response.Redirect("../default.aspx");
            }


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
            if (Request.QueryString["id"] != null)
            {
                apagarcampos();
            }
        }

        protected void buscarDoc_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negUser = new UsuarioNegocio();
            string filtro = $"numero_doc = {cargarTurno_documento.Text}";  
            List<Usuario> lista = new List<Usuario>();
            lista = negUser.buscarPor(filtro);
            if (lista.Count < 1) return; // aca poner mensaje de que no existe paciente con ese documento
            cargarTurno_paciente.Text = lista[0].nombreYApellido;
            cargarTurno_paciente.Attributes["value"] = lista[0].id.ToString();
        }

        protected void agregarPaciente_CLick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/ficha.aspx?rolId=4");
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

            if (Request.QueryString["idEditar"] != null)
            {
                TunoNegocio turnoNeg = new TunoNegocio();
                Turno turno = turnoNeg.verTurno(int.Parse(Request.QueryString["idEditar"]));
                cargarTurno_paciente.Text = turno.paciente.nombreYApellido;
                cargarTurno_paciente.Attributes["value"] = turno.paciente.id.ToString();
                cargaTurno_Esp.SelectedValue = turno.medico.especialidad.id.ToString();

                UsuarioNegocio negProf = new UsuarioNegocio();
                string filtro = $"especialidad = {cargaTurno_Esp.SelectedValue} AND bajaUsu IS NULL";
                List<Usuario> listaus = negProf.buscarPor(filtro);
                cargaTurno_prof.DataSource = listaus;
                cargaTurno_prof.DataValueField = "id";
                cargaTurno_prof.DataTextField = "nombreYApellido";
                cargaTurno_prof.DataBind();
                //cargaTurno_prof.Items.Insert(0, new ListItem("Selecciona un profesional", ""));
                cargaTurno_prof.SelectedValue = turno.medico.id.ToString();

                if (Request.QueryString["id"] != null)
                {
                    cargaTurno_fecha.Items.Insert(0, new ListItem(turno.fechaYHora.ToShortDateString(), ""));
                    cargaTurno_hora.Items.Insert(0, new ListItem(turno.fechaYHora.ToShortTimeString(), ""));
                }
                //cargaTurno_fecha.Text = turno.fechaYHora.ToString("dd/MM/yyyy");
                //cargaTurno_hora.Text = turno.fechaYHora.ToShortTimeString();
                cargarTurno_mot.Text = turno.observaciones.ToString();
                
                HorarioNegocio negHorario = new HorarioNegocio();
                filtro = $"WHERE id_medico = {cargaTurno_prof.SelectedValue} ORDER BY id_medico";

                listaHorarios = negHorario.listar(filtro);
                if (Request.QueryString["id"] == null) llenarFechas();
            }

                cargaTurno_prof.DataBind();
            cargaTurno_prof.Items.Insert(0, new ListItem("Selecciona un profesional", ""));
            //cargaTurno_prof.DataBind();

            //cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));
            //cargaTurno_fecha.DataBind();
            if (Request.QueryString["id"] == null)
            {
                cargaTurno_hora.Items.Insert(0, new ListItem("Selecciona un horario", ""));
            }

            //cargaTurno_hora.DataBind();


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
            List<ListItem> horarios = new List<ListItem>();
            List<DateTime> fechas = new List<DateTime>();
            listaHorarios.ForEach(lista =>
            {
                DiaSemana oDia = new DiaSemana();
                oDia = diaSem.Find(x => x.id == lista.idDia.id);
                int dia = (int)oDia.codDia;
                fechas.AddRange(devolverProximaFecha((DayOfWeek)dia, 3));
                fechas.Sort();
                //List<ListItem> horarios = new List<ListItem>();
                /*fechas.ForEach(x =>
                {
                    //cargaTurno_fecha.Items.Add(new ListItem(x.ToString("dd/MM/yyyy"), dia.ToString()));
                    horarios.Add(new ListItem(x.ToString("dd/MM/yyyy"), dia.ToString()));
                });*/
                //cargaTurno_fecha.DataSource = horarios;
                //cargaTurno_fecha.DataBind();
                //cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));
            });
            fechas.ForEach(x =>
            {
                //cargaTurno_fecha.Items.Add(new ListItem(x.ToString("dd/MM/yyyy"), dia.ToString()));
                horarios.Add(new ListItem(x.ToString("dd/MM/yyyy"), ((int)x.DayOfWeek).ToString()));
            });
            cargaTurno_fecha.DataSource = horarios;
            cargaTurno_fecha.DataBind();
            cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));
            /*
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
            cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));*/

        }
        protected void cargaTurno_fecha_changed(object sender, EventArgs e)
        {
            List<string> lsHoras = devolverHorarios();
            validoHorarios(lsHoras);
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

            int i = 0;
            while(i < cantidad)
            {
                DateTime proximaFechaObjetivo = fechaActual.AddDays(diasHastaObjetivo + (7 * i));
                if (proximaFechaObjetivo != DateTime.Today)
                {
                    proximasFechasObjetivo.Add(proximaFechaObjetivo);

                }
                else cantidad++;
                i++;
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
            if(Request.QueryString["idEditar"] == null)
            {
                if (cargar(objTurno)) turno.agregar(objTurno);
            }
            if(Request.QueryString["idEditar"] != null)
            {
                objTurno.id = int.Parse(Request.QueryString["idEditar"]);
                if (cargar(objTurno)) turno.editar(objTurno, 2);
            }

            lblAdvertencia.Text = "TURNO CREADO CORRECTAMENTE!";
            lblAdvertencia.ForeColor = System.Drawing.Color.Green;
            lblAdvertencia.Visible = true;
        }

        protected void volverTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmTurnos.aspx");
        }
        protected bool cargar(Turno obj)
        {
            EstadoNegocio negEstado = new EstadoNegocio();
            List<Estado> objEstado = negEstado.listar();
            string fecha = cargaTurno_fecha.Text;
            string hora = cargaTurno_hora.Text;
            if (cargaTurno_fecha.SelectedValue == "")
            {
                lblAdvertencia.Text = "Debe seleccionar una fecha para el turno";
                lblAdvertencia.Visible = true;
                return false;  // aca poner mensaje q no selecciono fecha
            }
            if (cargaTurno_hora.SelectedValue == "")
            {
                lblAdvertencia.Text = "Debe seleccionar un horario para el turno";
                lblAdvertencia.Visible = true;
                return false;  // aca poner mensaje q no selecciono horario.
            }
            if (cargarTurno_paciente.Text == "")
            {
                lblAdvertencia.Text = "Debe indicar un paciente, buscnadolo a traves de su Numero de Documento";
                lblAdvertencia.Visible = true;
                return false;  // aca poner mensaje q no selecciono horario.
            }

            DateTime fechaYhora = DateTime.Parse(fecha + " " + hora);
            Usuario objUserP = new Usuario();
            Usuario objUserM = new Usuario();
            objUserP.id = int.Parse(cargarTurno_paciente.Attributes["value"]);
            obj.paciente = objUserP;
            if (cargaTurno_prof.SelectedValue == "")
            {
                lblAdvertencia.Text = "Debe seleccionar un profecional para el turno";
                lblAdvertencia.Visible = true;
                return false; // aca poner mensaje q no selecciono profesional.
            }
            objUserM.id = int.Parse(cargaTurno_prof.SelectedValue);
            obj.medico = objUserM;
            obj.fechaYHora = fechaYhora;
            if (cargarTurno_mot.Text == "")
            {
                lblAdvertencia.Text = "Debe indicar motivo del turno";
                lblAdvertencia.Visible = true;
                return false; // aca poner mensaje de que el campo observaciones esta vacio
            }
            obj.observaciones = cargarTurno_mot.Text;
            obj.estado = objEstado.Find(x => x.defecto);
            return true;
        }
        protected void validoHorarios(List<string> lsHoras)
        {
            int idMedico = int.Parse(cargaTurno_prof.Text);
            string fecha = cargaTurno_fecha.Text;
            List<Turno> objTurno = new List<Turno>();
            objTurno = turno.listar($" AND T.id_medico = {idMedico} ");
            for( int i = lsHoras.Count() - 1; i > -1; i-- )
            {
                DateTime fecha_hora = DateTime.Parse(fecha + " " + lsHoras[i]);

                if (objTurno.Exists(x => x.fechaYHora == fecha_hora))
                {
                    lsHoras.RemoveAt(i);
                }
            }
        }
        protected void llenarFechas()
        {
            List<ListItem> horarios = new List<ListItem>();
            List<DateTime> fechas = new List<DateTime>();
            listaHorarios.ForEach(lista =>
            {
                DiaSemana oDia = new DiaSemana();
                oDia = diaSem.Find(x => x.id == lista.idDia.id);
                int dia = (int)oDia.codDia;
                fechas.AddRange(devolverProximaFecha((DayOfWeek)dia, 3));
                fechas.Sort();
            });
            fechas.ForEach(x =>
            {
                //cargaTurno_fecha.Items.Add(new ListItem(x.ToString("dd/MM/yyyy"), dia.ToString()));
                horarios.Add(new ListItem(x.ToString("dd/MM/yyyy"), ((int)x.DayOfWeek).ToString()));
            });
            cargaTurno_fecha.DataSource = horarios;
            cargaTurno_fecha.DataBind();
            cargaTurno_fecha.Items.Insert(0, new ListItem("Selecciona una fecha", ""));
        }
        protected void apagarcampos()
        {
            cargaTurno_Esp.Enabled = false;
            cargaTurno_prof.Enabled = false;
            cargaTurno_fecha.Enabled = false;
            cargaTurno_hora.Enabled = false;
            cargarTurno_mot.Enabled = false;
        }
    }   
}