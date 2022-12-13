<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Ayala_Herrera.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header bg-transparent">
            <div>
                <img src="img/cliente-proveedor2.png" alt="logoclienteproveedor" height="120" width="140" /><br />
                <h2>Listado de Proveedores</h2>
            </div>
            <div class="p-3">
                <asp:Button ID="btnAltaProveedor" tooltipCssClass="btn btn-dark" CssClass="btn btn-dark btn-lg" runat="server" Text="Alta de Proveedor" ToolTip="Alta nuevo proveedor" OnClick="btnAltaProveedor_Click" />
            </div>
        </div>
        <div class="card-body col-16 m-auto">
            <div>
                <asp:Label ID="lblFiltro" runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltro" OnClick="btnFiltro_Click" runat="server" CssClass="btn btn-secondary" Text="Buscar" />
                <asp:ImageButton ID="ibtnBorrarFiltro" OnClick="ibtnBorrarFiltro_Click" CssClass="align-middle m-1 btn" ImageUrl="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAAAXNSR0IArs4c6QAAAdxJREFUSEvFlo1Nw0AMhV8nASYBJilMAkxCmQSYBJgE9NA5enm1L3eIqpaitLnEn3/vvMOZZHcmLv4CvgRwA+ACwFcz/BPA24wTo2DC9gAeO8oD/jJixBZ4BOi2hAFPAPg7lR6Y0FcAvIcwnLze213DzvDzCiH0toJXYCr8MCX3AyF0Y0t4BaanYT3zyrCNiqcnhWfgZwB3jTILVeMepBgPABixRRxML+kthZZemZv0pioYX+N/OkGd/GaVKgertywM7U0q4Dqt99BXa1or1EWdv+JgFhRf9tCoAlqvcI+SV3LUyyqCClYFWW6Zd3ocaSCcbRWp4XOPEp9prpd1Bati5oOKXRyuPZ5B+b06tOitwCyqqogUHoZVUK5rmpZIKlhD0gOrBxr2Xq9/NwtTj1XhSNg0DV5wupamcKa43FMaF73a8zyNpILLnrM8efV6wXk76d6w8LyPtef8UAhAloZqTaO02hsc7BuFb5lJh3Uf6WGzMnjrkDja3CfIU4dE9F0MAL1q7dmg0OywKYe9/xoEqm20O2Vm0wSt5xWjT0Toum2NPvqUU8sphj0aszlAbIEjj/SeeYvJJMtv1APH23K6jA9HwWoAjYhTKYb6kw30E1009uqsx2NaB976AZMmmh/4QY5AAAAAAElFTkSuQmCC" runat="server" />
            </div>
            <br />

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
