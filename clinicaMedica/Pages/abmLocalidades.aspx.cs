﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicaMedica.Pages
{
    public partial class abmLocalidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Rol rolAux = new Rol();
            rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

            if (rolAux == null || rolAux.permisosConfiguracion == false)
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
                                    LocalidadNegocio negocio = new LocalidadNegocio();
                                    negocio.eliminar(id);

                                }
                            }
                        }
                    }
                }
            }
            LocalidadNegocio negocio2 = new LocalidadNegocio();
            GridAbmLocalidades.DataSource = negocio2.listar();
            GridAbmLocalidades.DataBind();
        }
    }
}