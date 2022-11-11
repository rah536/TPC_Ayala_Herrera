<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_Ayala_Herrera.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header">
            <h3>Listado de Categorias</h3>
             <div>
                <asp:Button ID="btnAltaCategoria" CssClass="btn btn-dark" runat="server" Text="Alta de Categoría" OnClick="btnAltaCategoria_Click" />
            </div>
        </div>
        

        <div class="card-body col-6 m-auto">
            <asp:GridView ID="gvCategorias" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged" OnRowDeleting="gvCategorias_RowDeleting" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Id Categoría" DataField="Id"/>
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" ControlStyle-CssClass="btn btn-info" HeaderText="Modificar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="220px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanel"  runat="server" Text="Desea Eliminar el Registro?"></asp:Label></h5>
            <asp:Button ID="btnPanelAceptar" CssClass="mt-5 mb-3 btn btn-success" runat="server" Text="Aceptar" OnClick="btnPanelAceptar_Click" />
            <asp:Button ID="btnPanelCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnPanelCancelar_Click" />
        </asp:Panel>
        <div class="card-footer mt-5">
            
        </div>
    </div>
</asp:Content>
