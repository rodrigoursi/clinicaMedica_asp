using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class usuario : System.Web.UI.Page
    {
        public int id { get; set; }
        public  int codigo { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string tipo_documento { get; set; }
        public string numero_doc { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<usuario> users = new List<usuario>();
                for(int i = 1; i < 10; i++)
                {
                    usuario user = new usuario(); // Crear una nueva instancia en cada iteración
                    user.codigo = 1111;
                    user.nombre = "rodrigo";
                    user.email = "rodrigo@rodrigo.com";
                    user.tipo_documento = "pasaporte";
                    user.numero_doc = "1213584584";
                    user.direccion = "lambare 500";
                    user.localidad = "escobar";
                    user.id = i;
                    users.Add(user);
                }
                GridAbmUser.DataSource = users;
                GridAbmUser.DataBind();
            }

        }
    }
}