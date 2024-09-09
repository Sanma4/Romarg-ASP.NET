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
    }
}