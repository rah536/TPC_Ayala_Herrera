<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Ayala_Herrera.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card text-center">
        <div class="card-header">
            <h3>Listado de Clientes</h3>
            <div>
                <asp:Button ID="btnAltaCliente" CssClass="btn btn-dark" runat="server" Text="Alta Cliente" OnClick="btnAltaCliente_Click" />
            </div>
        </div>
        

        <div class="card-body  col-6 m-auto">
            <asp:GridView ID="gvClientes" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" OnRowDeleting="gvClientes_RowDeleting" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id Cliente" DataField="Id"/>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="DNI" DataField="Dni" />
                    <asp:BoundField HeaderText="Cuit" DataField="Cuit" />
                    <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
                    <asp:BoundField HeaderText="Mail" DataField="Mail" />
                    <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Num Cliente" DataField="NumCliente" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-info" HeaderText="Modificar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="220px" Width="350px" runat="server">
                    <h5><asp:Label ID="lblPanel"  runat="server" Text="Desea Eliminar El Registro?"></asp:Label></h5>
                    <asp:Button ID="btnPanelAceptar" CssClass="mt-5 mb-3 btn btn-success" runat="server" Text="Aceptar" OnClick="btnPanelAceptar_Click"  />
                    <asp:Button ID="btnPanelCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnPanelCancelar_Click" />
        </asp:Panel>

        <div class="card-footer">

        </div>
    </div>
</asp:Content>
