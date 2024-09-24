using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Romarg_proyect.Home
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                VinosNegocio negocio = new VinosNegocio();

                repRepetidor.DataSource = negocio.ListarSP(id);
                repRepetidor.DataBind();

            }
        }

        protected void repRepetidor_Init(object sender, EventArgs e)
        {

        }
    }
}