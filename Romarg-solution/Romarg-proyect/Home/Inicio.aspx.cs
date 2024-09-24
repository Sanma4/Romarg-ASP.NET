using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using negocio;
using Negocio;

namespace Romarg_proyect.startbootstrap_agency_gh_pages
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VinosNegocio negocio = new VinosNegocio();
                Repeater1.DataSource = negocio.Listar();
                Repeater1.DataBind();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("VerDetalle.aspx?id=" + id);
        }

    }
}