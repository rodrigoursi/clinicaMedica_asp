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
                ambTurnos_dropListMed.DataBind();
                ambTurnos_dropListMed.Items.Insert(0, new ListItem("Todos", "0"));

                UsuarioNegocio usuarioNegocioPaciente = new UsuarioNegocio();
                ambTurnos_dropListPac.DataSource = usuarioNegocioMedico.listarNombres("4");
                ambTurnos_dropListMed.DataTextField = "nombreYApellido";
                ambTurnos_dropListPac.DataBind();
                ambTurnos_dropListPac.Items.Insert(0, new ListItem("Todos", "0"));

            
                TunoNegocio TurnoNegocio = new TunoNegocio();
                GridAbmLocalidades.DataSource = TurnoNegocio.listar((string)Session["whereSQL"]);
                GridAbmLocalidades.DataBind();

            
            }
        }

        protected void BuscarTurnos(object sender, EventArgs e)
        {


            if (ambTurnos_dropListEstado.SelectedValue != "0")
            {
                Session["estadoBuscar"] = ambTurnos_dropListEstado.SelectedValue;
                whereSql += " AND E.estado = '" + Session["estadoBuscar"] + "'";
            }

            if (ambTurnos_dropListMed.SelectedValue != "0")
            {
                Session["medicoBuscar"] = ambTurnos_dropListMed.SelectedValue;
                whereSql += " AND M.nombre_apellido = '" + Session["medicoBuscar"] + "'";
            }

            if (ambTurnos_dropListPac.SelectedValue != "0")
            {
                Session["pacienteBuscar"] = ambTurnos_dropListPac.SelectedValue;
                whereSql += " AND P.nombre_apellido = '" + Session["pacienteBuscar"] + "'";
            }

            if (ambTurnos_inputFecha.Text != "")
            {
                string fechaString = ambTurnos_inputFecha.Text;
                string fechaFormatted = string.Join("-", fechaString.Split('/').Reverse());
                Session["fechaBuscar"] = fechaFormatted;
                whereSql += " AND CAST(T.fecha_hora AS date) = '" + Session["fechaBuscar"] + "'";
            }

            Session["whereSQL"] = whereSql;

            Response.Redirect("ABMTurnos.aspx");
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
            string id_estado = ambTurnos_dropListEstado.SelectedValue;
            TunoNegocio TurnoNegocio = new TunoNegocio();
            if(id_estado != "0")
            {
                GridAbmLocalidades.DataSource = TurnoNegocio.listar($" AND T.estado={id_estado}");
            } else GridAbmLocalidades.DataSource = TurnoNegocio.listar((string)Session["whereSQL"]);

            GridAbmLocalidades.DataBind();
        }
    }
}