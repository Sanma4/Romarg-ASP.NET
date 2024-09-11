using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Romarg_proyect.Admin
{
    public partial class ListaVinos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VinosNegocio negocio = new VinosNegocio();
                Session.Add("listaVinos", negocio.ListarSP());
                dgvVinos.DataSource = Session["listaVinos"];
                dgvVinos.DataBind();
            }
        }

        protected void dgvVinos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvVinos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioVinos.aspx?id=" + id, false);
        }



        protected void dgvVinos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvVinos.PageIndex = e.NewPageIndex;
            dgvVinos.DataBind();
        }
    }
}