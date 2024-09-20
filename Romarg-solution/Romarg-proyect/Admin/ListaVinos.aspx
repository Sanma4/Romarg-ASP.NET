<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaVinos.aspx.cs" Inherits="Romarg_proyect.Admin.ListaVinos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:GridView runat="server" ID="dgvVinos" CssClass="table " AutoGenerateColumns="false"
        AllowPaging="true" PageSize="8" OnSelectedIndexChanged="dgvVinos_SelectedIndexChanged"
        OnPageIndexChanging="dgvVinos_PageIndexChanging" DataKeyNames="id">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Año" DataField="Anio" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Bodega" DataField="Bodega.Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Acciones" ShowSelectButton="true" SelectText="✍️" />
        </Columns>
    </asp:GridView>

    <asp:GridView runat="server" ID="dgvPrueba" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Bodega" DataField="bodega.Nombre" />
        </Columns>
    </asp:GridView>

    <a href="FormularioVinos.aspx" class="btn btn-success mb-3">Agregar</a>

</asp:Content>
