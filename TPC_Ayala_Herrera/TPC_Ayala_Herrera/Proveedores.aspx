<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Ayala_Herrera.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header">
            <h3>Listado Proveedores</h3>
             <div>
                 <asp:Button ID="btnAltaProveedor" tooltipCssClass="btn btn-dark" runat="server" Text="Alta Proveedor" ToolTip="Alta nuevo proveedor" OnClick="btnAltaProveedor_Click"/>
         


            </div>
        </div>
         <div class="card-body col-6 m-auto">
         <asp:GridView ID="gvProveedor" runat="server" CssClass="table table-striped" >
           <Columns>
             <asp:BoundField Datafield ="idProveedor" HeaderText ="ID Proveedor"/>
             <asp:BoundField Datafield ="idProducto" HeaderText ="ID Producto"/>
             <asp:BoundField Datafield ="razonSocial" HeaderText ="Razon Social"/>
                  </Columns>
         </asp:GridView>
        
             </div>
        <div class="card-body">
            
        </div>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
