<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductosAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.ProductosAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header">
            <h3>Alta de Productos</h3>
        </div>

        <div class="card-body fs-5">
            <div class="form-text btn-group-vertical m-auto">

                <asp:Label ID="lblCodigo" runat="server" Text="Código"></asp:Label> 
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label> 
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
                <asp:DropDownList ID="ddlProveedor" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList><br />
                
                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                <asp:DropDownList ID="ddlMarca" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList><br />
                
                <asp:Label ID="lblCategoria" runat="server" Text="Categoría"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList><br />
                
                <asp:Label ID="lblCostoUnidad" runat="server" Text="CostoUnidad"></asp:Label> 
                <asp:TextBox ID="txtCostoUnidad" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                <asp:Label ID="lblCantidadIngreso" runat="server" Text="Cantidad de productos a ingresar"></asp:Label> 
                <asp:TextBox ID="txtCantidadIngreso" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                <asp:Label ID="lblStockMinimo" runat="server" Text="Stock Mínimo"></asp:Label> 
                <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-text"></asp:TextBox> <br />

                <asp:Label ID="lblStockActual" runat="server" Text="Stock Actual"></asp:Label> 
                <asp:TextBox ID="txtStockActual" runat="server" CssClass="form-text"></asp:TextBox> <br />

                <asp:Label ID="lblPorcentajeGanancia" runat="server" Text="PorcentajeGanancia"></asp:Label> 
                <asp:TextBox ID="txtPorcentajeGanancia" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                <asp:Label ID="lblUrlImagen" runat="server" Text="UrlImagen"></asp:Label> 
                <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-text"></asp:TextBox> <br />
            
            </div>
        </div>

        <div class="card-footer mt-5">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click"  />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click"  />
        </div>
    </div>


</asp:Content>
