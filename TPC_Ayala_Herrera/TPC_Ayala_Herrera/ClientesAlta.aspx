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
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label> 
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese Nombre" ControlToValidate="txtNombre" style="color:red;"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Ingrese apellido" ControlToValidate="txtApellido" style="color:red;"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-1">
                    <asp:Label ID="lblDni" runat="server" Text="DNI"></asp:Label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revDni" runat="server" ErrorMessage="Ingresar solo números" ControlToValidate="txtDni" ValidationExpression="^\d+$" style="color:red;"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="rfvDni" runat="server" ErrorMessage="Ingrese DNI" ControlToValidate="txtDni" style="color:red;"></asp:RequiredFieldValidator>
                </div> 
                <div class="mb-3">
                    <asp:Label ID="lblCuit" runat="server" Text="Cuit"></asp:Label>
                    <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revCuit" runat="server" ErrorMessage="Ingresar solo números" ControlToValidate="txtCuit" ValidationExpression="^\d+$" style="color: red;"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio"></asp:Label>
                    <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control"></asp:TextBox> <br />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblMail" runat="server" Text="Mail"></asp:Label>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Email invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="color:red;" ControlToValidate="txtMail"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:   "></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox> <br />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNumCliente" runat="server" Text="Número de cliente:   "></asp:Label>
                    <asp:TextBox ID="txtNumCliente" runat="server" CssClass="form-control"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="rfvNumcliente" runat="server" ErrorMessage="Ingrese Número de Cliente" ControlToValidate="txtNumCliente" style="color:red;"></asp:RequiredFieldValidator>
                </div>
                 
            </div>
        </div>

        <asp:Panel ID="PanelModificadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelModificadoOk" runat="server" Text="El registro ha sido modificado"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelModificadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelModificadoOk_Click" />
        </asp:Panel>
        <asp:Panel ID="PanelAgregadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelAgregadoOk" runat="server" Text="El registro ha sido agregado"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelAgregadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelAgregadoOk_Click" />
        </asp:Panel>


        <div class="card-footer mt-5">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click"   />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click"  />
        </div>
    </div>




</asp:Content>
