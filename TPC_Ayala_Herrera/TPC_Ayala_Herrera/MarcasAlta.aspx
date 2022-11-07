<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MarcasAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.MarcasAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header">
            <h3>Alta de Marcas</h3>
        </div>

        <div class="card-body fs-5">
            <div class="d-inline-flex mt-4">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:   "></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-text"></asp:TextBox>
            </div>
        </div>

        <div class="card-footer mt-5">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click" />
        </div>
    </div>

</asp:Content>
