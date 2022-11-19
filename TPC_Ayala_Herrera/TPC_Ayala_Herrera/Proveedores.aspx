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
                <asp:Button ID="btnAltaProveedor" tooltipCssClass="btn btn-dark" CssClass="btn btn-dark btn-lg" runat="server" Text="Alta de Proveedor" ToolTip="Alta nuevo proveedor" OnClick="btnAltaProveedor_Click" />
            </div>
        </div>
        <div class="card-body col-16 m-auto">
            <asp:GridView ID="gvProveedor" AutoGenerateColumns="false" runat="server"  OnSelectedIndexChanged="gvProveedor_SelectedIndexChanged" OnRowDeleting ="gvProveedor_RowDeleting"  CssClass="table table-striped">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="idProveedor" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Razón social" DataField="razonSocial" />
                    <asp:BoundField HeaderText="DNI" DataField="dni" />
                    <asp:BoundField HeaderText="CUIT" DataField="cuit" />
                    <asp:BoundField HeaderText="Domicilio" DataField="domicilio" />
                    <asp:BoundField HeaderText="Mail" DataField="mail" />
                    <asp:BoundField HeaderText="Telefono" DataField="telefono" />
                    <asp:BoundField HeaderText="Rol" DataField="idRol" />
                    <asp:BoundField HeaderText="Fecha Alta" DataField="fechaAlta" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-info" HeaderText="Modificar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>


            </asp:GridView>



        </div>

        <asp:Panel ID="Panel1" Visible="false" BackColor="lightgray" CssClass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="220px" Width="350px" runat="server">
            <h5>
            <asp:Label ID="lblPanel" runat="server" Text="Desea Eliminar El Registro?"></asp:Label></h5>
            <asp:Button ID="btnPanelAceptar" CssClass="mt-5 mb-3 btn btn-success" runat="server" Text="Aceptar" OnClick="btnPanelAceptarProveedor_Click" />
            <asp:Button ID="btnPanelCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnPanelCancelarProveedor_Click" />
        </asp:Panel>
        <asp:Panel ID="PanelEliminadoOk" visible="false" BackColor="aliceblue" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelEliminadoOk" runat="server" Text="El registro ha sido eliminado"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelEliminadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelEliminadoOk_Click"/>
        </asp:Panel>


        <div class="card-footer">
        </div>
    </div>
</asp:Content>
