<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVinos.aspx.cs" Inherits="Romarg_proyect.Admin.FormularioVinos2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3" style="display: none;">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="TxtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Bodega</label>
                <asp:DropDownList ID="ddlBodega" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtAño" class="form-label">Año</label>
                <asp:TextBox ID="txtAño" CssClass="form-control" type="date" runat="server"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtUrlImage" runat="server" CssClass="form-control" OnTextChanged="txtUrlImage_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <asp:Image ImageUrl="https://www.womantowomanmentoring.org/wp-content/uploads/placeholder.jpg" runat="server" ID="PreloadImg" Style="width: 60%; height: auto;" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="row mb-3">
        <div class="col-4">
            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-outline-success" />
            <a href="ListaVinos.aspx" class="btn btn-outline-dark">Cancelar</a>
            <%if (BotonDesactivar)
                { %>
            <asp:Button Text="Desactivar" ID="btnDesactivar" CssClass="btn btn-warning" runat="server"  OnClick="btnDesactivar_Click"/>

            <%} %>
        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:TextBox runat="server" ID="txtAgregarBodega" CssClass="form-control  mb-3" placeholder="Ingrese la bodega" />
            <asp:DropDownList runat="server" ID="ddlAgregarBodega" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-4">
            <asp:Button Text="Agregar Bodega" ID="btnAgregarBodega" CssClass="btn btn-primary mb-3" runat="server" OnClick="btnAgregarBodega_Click" />
            <br />
            <asp:Button Text="Eliminar bodega" ID="btnEliminarBodega" runat="server" CssClass="btn btn-danger" OnClick="btnEliminarBodega_Click" />
            <br />
            <%if (ConfirmarEliminacion)
                {%>
            <asp:CheckBox runat="server" ID="chkEliminar" />

            <asp:Label Text="¿Desea eliminar esta bodega?" runat="server" />
            <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-outline-dark" ID="btnCancelar" OnClick="btnCancelar_Click" />
            <% } %>
        </div>
    </div>
</asp:Content>
