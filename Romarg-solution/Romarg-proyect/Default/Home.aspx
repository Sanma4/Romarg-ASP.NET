<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Romarg_proyect.Default.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExample" class="carousel slide mb-3">
        <div class="carousel-inner" style="width: 100%; height: 600px;">
            <div class="carousel-item active">
                <img src="https://www.finedininglovers.com/es/sites/g/files/xknfdk1706/files/2023-10/Vinos%20tintos%20dulces.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://www.finedininglovers.com/es/sites/g/files/xknfdk1706/files/2023-10/Vinos%20tintos%20dulces.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://www.finedininglovers.com/es/sites/g/files/xknfdk1706/files/2023-10/Vinos%20tintos%20dulces.jpg" class="d-block w-100" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <hr />
    <div class="container">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <%--            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%#Eval("UrlImage") %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>--%>
            <%
                foreach (Dominio.Vinos vino in ListaVinos)
                {
            %>
            <div class="col">
                <div class="card">
                    <img src="<%:vino.UrlImage %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%:vino.Nombre %></h5>
                        <p class="card-text"><%:vino.Descripcion %></p>
                        <a href="DetallePokemon.aspx?id=" <%:vino.Id %> class="btn btn-dark">Ver detalle</a>
                    </div>
                </div>
            </div>

            <%
                }
            %>
        </div>
    </div>
</asp:Content>
