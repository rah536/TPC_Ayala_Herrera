<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentasDetalle.aspx.cs" Inherits="TPC_Ayala_Herrera.VentasDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header">
            <h3>Detalle de Venta</h3>
        </div>
        <div class="card-body col-6 m-auto">
            <asp:GridView ID="gvVentasDetalle" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id Venta" DataField="IdVenta"/>
                    <asp:BoundField HeaderText="Código" DataField="Producto.Codigo"/>
                    <asp:BoundField HeaderText="Descripcion Producto" DataField="Producto.Descripcion"/>
                    <asp:BoundField HeaderText="Cantidad Vendida" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio por Unidad" DataField="Subtotal" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="card-footer">
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar a Listado" CssClass="btn btn-primary btn-lg" OnClick="btnRegresar_Click" />
        </div>
    </div>




</asp:Content>
