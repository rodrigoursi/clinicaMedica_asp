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
    public partial class abmProvincias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rol rolAux = new Rol();
                rolAux = (Rol)Session["currentRol"] != null ? (Rol)Session["currentRol"] : null;

                if (rolAux == null || rolAux.permisosConfiguracion == false)
                {
                    Response.Redirect("../default.aspx");
                }

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
                                    ProvinciaNegocio negocio = new ProvinciaNegocio();
                                    negocio.eliminar(id);

                                }
                            }
                        }
                    }
                }
            }

            ProvinciaNegocio negocio2 = new ProvinciaNegocio();
            GridAbmProvincias.DataSource = negocio2.listar();
            GridAbmProvincias.DataBind();
        }
    }
}