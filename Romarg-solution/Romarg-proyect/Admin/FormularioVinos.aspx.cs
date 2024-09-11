using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Romarg_proyect.Admin
{
    public partial class FormularioVinos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BodegaNegocio BodegaNegocio = new BodegaNegocio();
            TipoNegocio tipoNegocio = new TipoNegocio();
            try
            {
                ddlBodega.DataSource = BodegaNegocio.listarSP();
                ddlBodega.DataValueField = "Id";
                ddlBodega.DataTextField = "Nombre";
                ddlBodega.DataBind();

                ddlTipo.DataSource = tipoNegocio.listarSP();
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataTextField = "Descripcion";
                ddlTipo.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("..\\Default\\Error.aspx");
                
            }
        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {
            PreloadImg.ImageUrl = txtUrlImage.Text;
        }
    }
}