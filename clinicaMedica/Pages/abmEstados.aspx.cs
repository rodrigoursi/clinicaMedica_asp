using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmEstados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Configuración de la GridView
                EstadoNegocio negocio = new EstadoNegocio();
                GridAbmEstados.DataSource = negocio.listar();
                GridAbmEstados.DataBind();

            }
        }

        //protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Eliminar")
        //    {
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = GridAbmEstados.Rows[rowIndex];
        //        byte id = Convert.ToByte(GridAbmEstados.DataKeys[row.RowIndex].Value);

        //        EliminarRegistro(id);

        //        // Volver a enlazar los datos a la GridView
        //        GridAbmEstados.DataBind();
        //    }


        //}
        //private void EliminarRegistro(byte id)
        //{
        //    EstadoNegocio negocio = new EstadoNegocio();
        //    negocio.eliminar(id);
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Title = e.ToString();
            EstadoNegocio negocio = new EstadoNegocio();
            negocio.eliminar(3);
        }
    }
}