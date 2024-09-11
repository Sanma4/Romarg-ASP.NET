<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVinos.aspx.cs" Inherits="Romarg_proyect.Admin.FormularioVinos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
            <div class="col-4">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox ID="txtDescripcion" type="text-area" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlTipo" class="form-label">Tipo</label>
                    <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlTipo" class="form-label">Bodega</label>
                    <asp:DropDownList ID="ddlBodega" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <div class="mb-3">
                    <label for="txtAño" class="form-label">Año</label>
                    <asp:TextBox ID="txtAño" type="date" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">UrlImage</label>
                    <asp:TextBox ID="txtUrlImage" runat="server" OnTextChanged="txtUrlImage_TextChanged"></asp:TextBox>
                </div>
                <asp:Image ImageUrl="https://www.womantowomanmentoring.org/wp-content/uploads/placeholder.jpg" runat="server" ID="PreloadImg" style="width: 40%; height: auto;" />
            </div>
        </div>
</asp:Content>
