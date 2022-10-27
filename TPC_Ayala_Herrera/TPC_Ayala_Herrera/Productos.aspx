<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Ayala_Herrera.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header">
            <h3>Header Productos</h3>
        </div>
        <div class="card-body">
            <h3>Body Productos</h3>
            <asp:GridView ID="gvProductos" CssClass="table" runat="server"></asp:GridView>
        </div>
        <div class="card-footer">
            <h3>Footer Productos</h3>
        </div>
    </div>
</asp:Content>
