<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductosDetalle.aspx.cs" Inherits="TPC_Ayala_Herrera.ProductosDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header bg-transparent">
            <div>
                <h2>Detalle de Producto</h2>
            </div>

        </div>

        <div class="card-body">
            
            <% 
                int idProd = int.Parse( Request.QueryString["id"].ToString());
                foreach (Dominio.Producto prod in Listaproducto)
                { %>


            <div class="card-deck">

                <div class="card"> 
                    <% if (prod.Id == idProd)
                        { %>
                    <img src="<%:prod.UrlImagen %>" " class="card-img-top" alt="ImgArt" width="200" height="250">
                    <div class="card-body">
                        <h5 class="card-title"><%: prod.Descripcion %></h5>
                        <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    </div>
                    <div class="card-footer">
                        <small class="text-muted">Last updated 3 mins ago</small>
                    </div>
                </div>
                    <%
                        }

                            %>
           
               <% }
                %>
              
            </div>







        </div>

        <div class="card-footer">
        </div>
    </div>

</asp:Content>
