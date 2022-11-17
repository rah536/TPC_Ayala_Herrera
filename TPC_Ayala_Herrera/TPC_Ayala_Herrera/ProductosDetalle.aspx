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




            <div class="card-group">
                    <% if (prod.Id == idProd)
                        { %>
  <div class="card mb-3" style="max-width: 320px; margin:0px auto;"  >
    <img class="card-img-top" src="<%:prod.UrlImagen %>" alt="Card image cap">
    <div class="card-body">
      <h5 class="card-title"><%: prod.Descripcion %></h5>
      <p class="card-text"> <%: prod.Categoria.Descripcion %></p>
    </div>
    <div class="card-footer">
      <small class="text-muted">$  <%: prod.CostoUnidad %></small>
    </div>
  </div>



                       <%
                        }

                            %>
           

</div>



                <% }
                %>













     







        </div>

        <div class="card-footer">
        </div>
    </div>

</asp:Content>
