<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Ayala_Herrera.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header bg-transparent">
            <div>
                <h2>Listado de Proveedores</h2>
            </div>
             <div class="p-3">
                 <asp:Button ID="btnAltaProveedor" tooltipCssClass="btn btn-dark" CssClass="btn btn-dark btn-lg" runat="server" Text="Alta de Proveedor" ToolTip="Alta nuevo proveedor" OnClick="btnAltaProveedor_Click"/>
            </div>
        </div>
         <div class="card-body col-16 m-auto">
         <asp:GridView ID="gvProveedor" runat="server" CssClass="table table-striped" >

           

         </asp:GridView>
        
             </div>
        <div class="card-body">
            
        </div>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
