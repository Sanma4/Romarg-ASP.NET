using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Romarg_proyect.Admin
{
    public partial class FormularioVinos2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BodegaNegocio BodegaNegocio = new BodegaNegocio();
            TipoNegocio tipoNegocio = new TipoNegocio();
            try
            {
                if (!IsPostBack)
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
                
                string id = Request.QueryString["id"] != null ?  Request.QueryString["id"].ToString() : "";
                if(id != "" && !IsPostBack)
                {
                    VinosNegocio negocio = new VinosNegocio();
                    Vinos seleccionado = (negocio.ListarSP(id))[0];

                    Session.Add("vinoSeleccionado", seleccionado);

                    TxtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtAño.Text = seleccionado.Anio.ToString("yyyy-MM-dd");
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImage.Text = seleccionado.UrlImage;

                    ddlBodega.SelectedValue = seleccionado.Bodega.Id.ToString();
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    txtUrlImage_TextChanged(sender, e);

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", Validacion.ValidarVacio(ex));
                Response.Redirect("..\\Default\\Error.aspx");

            }
        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {
            PreloadImg.ImageUrl = txtUrlImage.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            VinosNegocio negocio = new VinosNegocio();
            try
            {
                Vinos vino = new Vinos();
                vino.Nombre = txtNombre.Text;
                vino.Descripcion = txtDescripcion.Text;
                vino.Anio = DateTime.Parse(txtAño.Text);
                vino.UrlImage = txtUrlImage.Text;
                vino.Tipo = new Tipo();
                vino.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                vino.Bodega = new Bodega();
                vino.Bodega.Id = int.Parse(ddlBodega.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    vino.Id = int.Parse(TxtId.Text);
                    negocio.Modificar(vino);
                }
                else
                {

                    negocio.AgregarVinoSP(vino);
                }
                Response.Redirect("ListaVinos.aspx", false);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", Validacion.ValidarVacio(ex));
                Response.Redirect("..\\Default\\Error.aspx");
            }
        }
    }
}