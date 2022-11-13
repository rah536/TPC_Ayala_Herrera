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
                <asp:Button ID="btnAltaProducto" CssClass="btn btn-dark btn-lg" runat="server" Text="Alta de Producto" OnClick="btnAltaProducto_Click" />
            </div>
        </div>
          
        <div class="card-body col-6 m-auto">
            <asp:GridView ID="gvProductos" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" OnRowDeleting="gvProductos_RowDeleting"  AutoGenerateColumns="false" CssClass="table table-striped" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id Producto" DataField="Id"/>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.RazonSocial" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Stock" DataField="StockActual" />
                    <asp:BoundField HeaderText="Stock mínimo" DataField="StockMinimo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Modificar" ControlStyle-CssClass="btn btn-info" HeaderText="Modificar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="220px" Width="350px" runat="server">
                    <h5><asp:Label ID="lblPanel"  runat="server" Text="Desea Eliminar El Registro?"></asp:Label></h5>
                    <asp:Button ID="btnPanelAceptar" CssClass="mt-5 mb-3 btn btn-success" runat="server" Text="Aceptar" OnClick="btnPanelAceptar_Click"  />
                    <asp:Button ID="btnPanelCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnPanelCancelar_Click"   />
        </asp:Panel>

        <div class="card-footer">
            
        </div>
    </div>
</asp:Content>
