<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Ayala_Herrera.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header">
            <h3>Listado Proveedores</h3>
             <div>
                <asp:Button ID="btnAltaProveedor" CssClass="btn btn-dark" runat="server" Text="Alta Proveedor" />
         


            </div>
        </div>
         <asp:GridView ID="gvProveedor" runat="server"></asp:GridView>
        

        <div class="card-body">
            
        </div>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
