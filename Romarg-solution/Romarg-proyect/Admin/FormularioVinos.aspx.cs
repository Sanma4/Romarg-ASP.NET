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
        public bool ConfirmarEliminacion { get; set; }
        public bool BotonDesactivar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BodegaNegocio BodegaNegocio = new BodegaNegocio();
            TipoNegocio tipoNegocio = new TipoNegocio();
            try
            {
                BotonDesactivar = false;
                if (!IsPostBack)
                {

                    CargarDdl();

                    ddlTipo.DataSource = tipoNegocio.listarSP();
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
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

                    BotonDesactivar = true;
                    if (!seleccionado.Activo)
                        btnDesactivar.Text = "Activar";
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
        protected void btnAgregarBodega_Click(object sender, EventArgs e)
        {

            try
            {
                BodegaNegocio negocio = new BodegaNegocio();
                negocio.AgregarBodega(txtAgregarBodega.Text);
                CargarDdl();
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validacion.ValidarVacio(ex.ToString()));
                Response.Redirect("..\\Default\\Error.aspx");
            }
        }

        protected void btnEliminarBodega_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
            try
            {
                if (chkEliminar.Checked)
                {
                    BodegaNegocio negocio = new BodegaNegocio();
                    negocio.EliminarBodega(int.Parse(ddlAgregarBodega.SelectedValue));
                    CargarDdl();
                    ConfirmarEliminacion = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validacion.ValidarVacio(ex.ToString()));
                Response.Redirect("..\\Default\\Error.aspx");
            }
        }

        public void CargarDdl()
        {
            BodegaNegocio negocio = new BodegaNegocio();
            try
            {
                ddlAgregarBodega.DataSource = negocio.listarSP();
                ddlAgregarBodega.DataValueField = "Id";
                ddlAgregarBodega.DataTextField = "Nombre";
                ddlAgregarBodega.DataBind();

                ddlBodega.DataSource = negocio.listarSP();
                ddlBodega.DataValueField = "Id";
                ddlBodega.DataTextField = "Nombre";
                ddlBodega.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validacion.ValidarVacio(ex.ToString()));
                Response.Redirect("..\\Default\\Error.aspx");
            }

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                VinosNegocio negocio = new VinosNegocio();
                Vinos seleccionado = new Vinos();
                seleccionado = (Vinos)Session["vinoSeleccionado"];
                negocio.DesactivarVino(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("ListaVinos.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("Error", Validacion.ValidarVacio(ex.ToString()));
                Response.Redirect("..\\Default\\Error.aspx");
            }
        }
    }
}