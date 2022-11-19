<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriasAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.CategoriasAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header">
            <h3>Alta de Categorías</h3>
        </div>

        <div class="card-body fs-5">
            <div class="d-inline-flex mt-4">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:   "></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-text"></asp:TextBox>
            </div>
        </div>


        <asp:Panel ID="PanelModificadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelModificadoOk" runat="server" Text="El registro ha sido modificado"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelModificadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelModificadoOk_Click"/>
        </asp:Panel>
        <asp:Panel ID="PanelAgregadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelAgregadoOk" runat="server" Text="El registro ha sido agregado"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelAgregadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelAgregadoOk_Click"  />
        </asp:Panel>


        <div class="card-footer mt-5">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
