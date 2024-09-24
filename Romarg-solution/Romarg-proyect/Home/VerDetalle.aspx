<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="Romarg_proyect.Home.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <section class="py-5">
        <asp:Repeater runat="server" ID="repRepetidor" OnInit="repRepetidor_Init">
            <ItemTemplate>
                <div class="container px-4 px-lg-5 my-5">
                    <div class="row gx-4 gx-lg-5 align-items-center">
                        <div class="col-md-6">
                            <img class="card-img-top mb-5 mb-md-0" src="<%#Eval("UrlImage") %>" alt="..." />
                        </div>
                        <div class="col-md-6">

                            <h3 class="display-5 fw-bolder"><%#Eval("Nombre") %></h3>
                            <p class="lead"><%#Eval("Descripcion") %></p>
                        </div>
                    </div>
                </div>
                </section>
            </ItemTemplate>
        </asp:Repeater>
</asp:Content>
