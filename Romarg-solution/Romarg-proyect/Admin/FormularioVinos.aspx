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
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" type="text-area" runat="server"></asp:TextBox>
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
    <div class="row">
        <div class="col-4">
            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-outline-success" />
            <a href="ListaVinos.aspx" class="btn btn-outline-dark">Cancelar</a>
        </div>
    </div>
</asp:Content>
