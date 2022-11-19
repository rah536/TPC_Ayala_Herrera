<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_Ayala_Herrera.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header bg-transparent">
            <div>
                <h2>Listado de Marcas</h2>
            </div>
             <div class="p-3">
                <asp:Button ID="btnAltaMarca" CssClass="btn btn-dark btn-lg" runat="server" Text="Alta de Marca" OnClick="btnAltaMarca_Click" />
            </div>
        </div>
        
        <div class="card-body col-6 m-auto">
            <asp:GridView ID="gvMarcas" OnSelectedIndexChanged="gvMarcas_SelectedIndexChanged" OnRowDeleting="gvMarcas_RowDeleting" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id Marca" DataField="Id"/>
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-info" HeaderText="Modificar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="220px" Width="350px" runat="server">
                    <h5><asp:Label ID="lblPanel"  runat="server" Text="Desea Eliminar El Registro?"></asp:Label></h5>
                    <asp:Button ID="btnPanelAceptar" CssClass="mt-5 mb-3 btn btn-success" runat="server" Text="Aceptar" OnClick="btnPanelAceptar_Click"  />
                    <asp:Button ID="btnPanelCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnPanelCancelar_Click"  />
        </asp:Panel>
        <asp:Panel ID="PanelEliminadoOk" visible="false" BackColor="aliceblue" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelEliminadoOk" runat="server" Text="El registro ha sido eliminado"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelEliminadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelEliminadoOk_Click"/>
        </asp:Panel>

        <div class="card-footer">
            
        </div>
    </div>

</asp:Content>
