using Dominio;
using Negocio;
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

            string codUser = codigoUser.Text;
            string passUser = pass.Text;

            UsuarioNegocio usuarioDb = new UsuarioNegocio();
            Usuario currentUser = usuarioDb.login(codUser, passUser);

            if (currentUser.id == 0)
            {
                loginMsg.Text = "ERROR: Usuario y/o contraseña incorrecta";

            }
            else
            {
                //Response.Redirect("/default.aspx");

                Session.Add("usuario", codUser);
                Session.Add("rol", "admin");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("rol");
        }
    }
}