<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Ayala_Herrera.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header bg-transparent">
            <div>
                <h2>Listado de Productos</h2>
            </div>
            <div class="p-3">
                <asp:Button ID="btnAltaProducto" CssClass="btn btn-dark btn-lg" runat="server" Text="Alta de Producto" />
            </div>
        </div>
          
        <div class="card-body">
            <asp:GridView ID="gvProductos" CssClass="table table-striped" runat="server"></asp:GridView>
        </div>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
