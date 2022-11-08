<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Ayala_Herrera.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-center">
        <div class="card-header">
            <h3>Listado Proveedores</h3>
             <div>
                <asp:Button ID="btnAltaProveedor" CssClass="btn btn-dark" runat="server" Text="Alta Proveedor" />
          <div class="card-body col-6 m-auto">
            <asp:GridView ID="gvProveedor" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id Proveedor" DataField="Id"/>
                    <asp:BoundField HeaderText="Razon Social" DataField="razonSocial" />
                    <asp:BoundField HeaderText="Id Producto" DataField="idProducto" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-info" HeaderText="Modificar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
            </div>
        </div>

        

        <div class="card-body">
            
        </div>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
