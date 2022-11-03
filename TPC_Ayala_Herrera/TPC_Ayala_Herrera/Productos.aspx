<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Ayala_Herrera.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header">
            <h3>Listado de Productos</h3>
            <div>
                <asp:Button ID="btnAltaProducto" CssClass="btn btn-dark" runat="server" Text="Alta Producto" />
            </div>
        </div>
          
        <div class="card-body">
            <asp:GridView ID="gvProductos" CssClass="table table-striped" runat="server"></asp:GridView>
        </div>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
