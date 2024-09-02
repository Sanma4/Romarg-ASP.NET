<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaVinos.aspx.cs" Inherits="Romarg_proyect.Admin.ListaVinos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvVinos" CssClass="table table-hover" AutoGenerateColumns="false"
        AllowPaging="true" PageSize="8">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Año" DataField="Año"/>
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion"/>
            <asp:BoundField HeaderText="Bodega" DataField="Bodega.Descripcion"/>
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>
        </Columns>
    </asp:GridView>
</asp:Content>
