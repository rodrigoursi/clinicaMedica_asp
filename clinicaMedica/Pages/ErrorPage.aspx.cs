using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["errorMessage"]))
            {
                ErrorMessageLiteral.Text = Server.HtmlEncode(Request.QueryString["errorMessage"]);
            }
            else
            {
                ErrorMessageLiteral.Text = "Ha ocurrido un error.";
            }
        }
    }
}