using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string usuario = login.Text;
            Session.Add("usuario", usuario);
            Session.Add("rol", "admin");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("rol");
        }
    }
}