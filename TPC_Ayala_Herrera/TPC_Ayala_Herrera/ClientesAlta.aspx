<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientesAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.ClientesAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
        <div class="card-header">
            <h3>Alta de Clientes</h3>
        </div>

        <div class="card-body fs-5">
            <div class="form-text btn-group-vertical m-auto">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:   "></asp:Label> 
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:   "></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblDni" runat="server" Text="DNI:   "></asp:Label>
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblCuit" runat="server" Text="Cuit:   "></asp:Label>
                <asp:TextBox ID="txtCuit" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio:   "></asp:Label>
                <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblMail" runat="server" Text="Mail:   "></asp:Label>
                <asp:TextBox ID="txtMail" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:   "></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-text"></asp:TextBox> <br />
                <asp:Label ID="lblNumCliente" runat="server" Text="Número de cliente:   "></asp:Label>
                <asp:TextBox ID="txtNumCliente" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
            </div>
        </div>

        <div class="card-footer mt-5">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click"   />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click"  />
        </div>
    </div>




</asp:Content>
