using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmTurnos : System.Web.UI.Page
    {
        string whereSql ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            if (rolAux == null)// || rolAux.permisosModificarTurno == false)
            {
                Response.Redirect("../default.aspx");
            }

            if (!IsPostBack)
            {
               
                if (Request.QueryString["mod"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        byte id;
                        if (byte.TryParse(Request.QueryString["id"], out id))
                        {
                            byte mod;
                            if (byte.TryParse(Request.QueryString["mod"], out mod))
                            {
                                if (mod == 3) //ELIMINAR
                                {
                                    TunoNegocio negocio = new TunoNegocio();
                                    negocio.eliminar(id);

                                }
                            }
                        }
                    }
                }

                EstadoNegocio estadoNegocio = new EstadoNegocio();
                ambTurnos_dropListEstado.DataSource = estadoNegocio.listar();
                ambTurnos_dropListEstado.DataTextField = "estado";
                ambTurnos_dropListEstado.DataValueField = "id";
                ambTurnos_dropListEstado.DataBind();
                ambTurnos_dropListEstado.Items.Insert(0, new ListItem("Todos", "0"));

                UsuarioNegocio usuarioNegocioMedico = new UsuarioNegocio();
                ambTurnos_dropListMed.DataSource = usuarioNegocioMedico.listarNombres("3");
                ambTurnos_dropListMed.DataTextField = "nombreYApellido";
                ambTurnos_dropListMed.DataValueField = "id";
                ambTurnos_dropListMed.DataBind();
                ambTurnos_dropListMed.Items.Insert(0, new ListItem("Todos", "0"));

                UsuarioNegocio usuarioNegocioPaciente = new UsuarioNegocio();
                ambTurnos_dropListPac.DataSource = usuarioNegocioMedico.listarNombres("4");
                ambTurnos_dropListPac.DataTextField = "nombreYApellido";
                ambTurnos_dropListPac.DataValueField = "id";
                ambTurnos_dropListPac.DataBind();
                ambTurnos_dropListPac.Items.Insert(0, new ListItem("Todos", "0"));

                BuscarTurnos(null, null);

                //string filtro = (string)Session["filtro"]!=null? (string)Session["filtro"]: "";

                //if (rolAux != null && rolAux.permisosModificarTurno == true)
                //{
                //    //ambTurnos_dropListMed.SelectedValue = false;


                //    TunoNegocio TurnoNegocio = new TunoNegocio();
                //    GridAbmTurnos.DataSource = TurnoNegocio.listar(filtro);
                //    GridAbmTurnos.DataBind();
                //}
                //else 
                //{


                //    TunoNegocio TurnoNegocio = new TunoNegocio();
                //    GridAbmTurnos2.DataSource = TurnoNegocio.listar(filtro);
                //    GridAbmTurnos2.DataBind();

                //}

            }
        }

        protected void mostrarTurnosHoy_Click(object sender, EventArgs e)
        {
            ambTurnos_inputFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            BuscarTurnos(null, null);
        }

        protected void BuscarTurnos(object sender, EventArgs e)
        {
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            string filtro = "";

            if (ambTurnos_dropListEstado.SelectedValue != "0")
            {
                string id_estado = ambTurnos_dropListEstado.SelectedValue;
                filtro += $" AND T.estado={id_estado}";
                /*Session["estadoBuscar"] = ambTurnos_dropListEstado.SelectedValue;
                whereSql += " AND E.estado = '" + Session["estadoBuscar"] + "'";*/
            }

            if (ambTurnos_dropListMed.SelectedValue != "0")
            {
                string id_medico = ambTurnos_dropListMed.SelectedValue;
                filtro += $" AND id_medico={id_medico}";
                
                /*
                Session["medicoBuscar"] = ambTurnos_dropListMed.SelectedValue;
                whereSql += " AND M.nombre_apellido = '" + Session["medicoBuscar"] + "'";
                */
            }

            if (ambTurnos_dropListPac.SelectedValue != "0")
            {
                string id_paciente = ambTurnos_dropListPac.SelectedValue;
                filtro += $" AND id_paciente={id_paciente}";
                /*
                Session["pacienteBuscar"] = ambTurnos_dropListPac.SelectedValue;
                whereSql += " AND P.nombre_apellido = '" + Session["pacienteBuscar"] + "'";
                */
            }
            
            Session["filtro"] = filtro;

            if (ambTurnos_inputFecha.Text != "")
            {
                string fechaString = ambTurnos_inputFecha.Text;
                string fechaFormatted = string.Join("-", fechaString.Split('/').Reverse());
                filtro += $" AND CONVERT(date,fecha_hora,103) ='{fechaFormatted}'";

                /*Session["fechaBuscar"] = fechaFormatted;
                whereSql += " AND CAST(T.fecha_hora AS date) = '" + Session["fechaBuscar"] + "'";*/
            }

            if (rolAux != null && rolAux.permisosModificarTurno == true)
            {
                TunoNegocio TurnoNegocio = new TunoNegocio();
                //GridAbmTurnos.DataSource = TurnoNegocio.listar((string)Session["whereSQL"]);
                GridAbmTurnos.DataSource = TurnoNegocio.listar(filtro);
                GridAbmTurnos.DataBind();
            }
            else
            {
                if (Session["usuario"] != null)
                {
                    string nombreYApellido = ((string)Session["usuario"]);

                    ListItem itemSeleccionado = ambTurnos_dropListMed.Items.FindByText(nombreYApellido);

                    if (itemSeleccionado != null)
                    {
                        itemSeleccionado.Selected = true; // aca estoy haciendo que el campo medico sea el del usuario medico
                        filtro += $" AND M.nombre_apellido = '" + itemSeleccionado + "'";
                    }
                }

                TunoNegocio TurnoNegocio = new TunoNegocio();
                GridAbmTurnos2.DataSource = TurnoNegocio.listar(filtro);
                GridAbmTurnos2.DataBind();
            }


        }

        protected void grabarDiagnostico_Click(object sender, EventArgs e)
        {
            TunoNegocio turnoNeg = new TunoNegocio();
            string valor = diagnostico.Text;
            int id = int.Parse(Request.QueryString["id"]);
            if(turnoNeg.setDiagnostico(valor, id))
            {
                Response.Redirect("/pages/ABMTurnos.aspx"); //aca falta poner la url con la logica  q es medico
            }
            
        }

        protected void ambTurnos_listEstado_selChanged(object sender, EventArgs e)
        {
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            string id_estado = ambTurnos_dropListEstado.SelectedValue;
            string id_medico = ambTurnos_dropListMed.SelectedValue;
            string id_paciente = ambTurnos_dropListPac.SelectedValue;
            string fechaString = ambTurnos_inputFecha.Text;
            string filtro = "";
            TunoNegocio TurnoNegocio = new TunoNegocio();
            /*
            if(id_estado != "0")
            {
                GridAbmLocalidades.DataSource = TurnoNegocio.listar($" AND T.estado={id_estado}");
            } else GridAbmLocalidades.DataSource = TurnoNegocio.listar((string)Session["whereSQL"]);
            */


            if (id_estado != "0")
            {
                filtro += $" AND T.estado={id_estado}";
            }
            
            if (id_medico != "0")
            {
                filtro += $" AND id_medico={id_medico}";
            }
            
            if (id_paciente != "0")
            {
                filtro += $" AND id_paciente={id_paciente}";
            }

            if (fechaString != "")
            {
                string fechaFormatted = string.Join("-", fechaString.Split('/').Reverse());
                filtro += $" AND CONVERT(date,fecha_hora,103) ='{fechaFormatted}'";
            }

            if (rolAux != null && rolAux.permisosModificarTurno == true)
            {
                GridAbmTurnos.DataSource = TurnoNegocio.listar(filtro);
                GridAbmTurnos.DataBind();
            }
            else
            {
                GridAbmTurnos2.DataSource = TurnoNegocio.listar(filtro);
                GridAbmTurnos2.DataBind();
            }
        }
    }
}