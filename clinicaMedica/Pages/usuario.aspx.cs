using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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

        public string[] permisos { get; set; }

        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    permisos = new string[] { "admin" };

        //    if (Session["usuario"] == null)
        //    {
        //        Response.Redirect("/");
        //    }
        //    foreach (var item in permisos)
        //    {
        //        if (item != Session["currentRol"].ToString())
        //        {
        //            Response.Redirect("/");
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["mod"] != null)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        byte id = 0;
                        if (byte.TryParse(Request.QueryString["id"], out id))
                        {
                            byte mod;
                            if (byte.TryParse(Request.QueryString["mod"], out mod))
                            {
                                if (mod == 3) //ELIMINAR
                                {
                                    UsuarioNegocio negocio = new UsuarioNegocio();
                                    negocio.eliminar(id);

                                }
                            }
                        }
                    }
                }
            }
            byte idRol;
            if (byte.TryParse(Request.QueryString["rolId"], out idRol))
            {
                UsuarioNegocio negocio2 = new UsuarioNegocio();
                GridAbmUser.DataSource = negocio2.listar(idRol);
                GridAbmUser.DataBind();
            }
        }
    }
}