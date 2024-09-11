using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Romarg_proyect.Default
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Vinos> ListaVinos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            VinosNegocio negocio = new VinosNegocio();
            try
            {
                ListaVinos = negocio.ListarSP();
                if (IsPostBack)
                {
                    //repRepetidor.DataSource = negocio.ListarSP();
                    //repRepetidor.DataBind(); 
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Validaciones.ManejoError(ex));
                Response.Redirect("Default\\Error.aspx", false);
            }
        }
    }
}