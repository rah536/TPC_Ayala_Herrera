<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProveedoresAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="card text-center">
                <div class="card-header">
                    <h3>Datos nuevo proveedor</h3>
               </div>

                <div class="card-body fs-5">
                    <div class="form-text btn-group-vertical m-auto">

                        <div class="mb-3">
                            <asp:Label ID="lvRazonSocial" runat="server" Text="Razon Social:   " CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="tbRazonSocial" runat="server" CssClass="form-control"></asp:TextBox><br>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lvNombre" runat="server" Text="Nombre :   "></asp:Label>
                            <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox><br>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lvApellido" runat="server" Text="Apellido :   "></asp:Label>
                            <asp:TextBox ID="tbApellido" runat="server" CssClass="form-control"></asp:TextBox><br>
                        </div>
                        <div class="mb-1">
                            <asp:Label ID="lbDni" runat="server" Text="DNI :   "></asp:Label>
                            <asp:TextBox ID="tbDni" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revDni" runat="server" ErrorMessage="Ingresar solo números" ControlToValidate="tbDni" ValidationExpression="^\d+$" style="color:red;"></asp:RegularExpressionValidator><br />
                            <asp:RequiredFieldValidator ID="rfvDni" runat="server" ErrorMessage="Ingrese DNI" ControlToValidate="tbDni" style="color:red;"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-1">
                            <asp:Label ID="lbCuit" runat="server" Text="CUIT :   "></asp:Label>
                            <asp:TextBox ID="tbCuit" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revCuit" runat="server" ErrorMessage="Ingresar solo números" ControlToValidate="tbCuit" ValidationExpression="^\d+$" style="color:red;"></asp:RegularExpressionValidator><br />
                            <asp:RequiredFieldValidator ID="rfvCuit" runat="server" ErrorMessage="Ingrese Cuit" ControlToValidate="tbCuit" style="color:red;"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lbDomicilio" runat="server" Text="Domicilio :   "></asp:Label>
                            <asp:TextBox ID="tbDomicilio" runat="server" CssClass="form-control"></asp:TextBox><br>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lbMail" runat="server" Text="Mail :   "></asp:Label>
                            <asp:TextBox ID="tbMail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Ingrese un mail válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="color:red;" ControlToValidate="tbMail"></asp:RegularExpressionValidator>
                        </div>
                        <div class="mb-6">
                            <asp:Label ID="lbTelefono" runat="server" Text="Telefono :   "></asp:Label>
                            <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
               </div>

             <asp:Panel ID="PanelModificadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
                <h5><asp:Label ID="lblPanelModificadoOk" runat="server" Text="El registro ha sido modificado"></asp:Label></h5>
                <asp:Button ID="btnCerrarPanelModificadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelModificadoOk_Click"/>
            </asp:Panel>
            <asp:Panel ID="PanelAgregadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
                <h5><asp:Label ID="lblPanelAgregadoOk" runat="server" Text="El registro ha sido agregado"></asp:Label></h5>
                <asp:Button ID="btnCerrarPanelAgregadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelAgregadoOk_Click" />
            </asp:Panel>

            <div class="card-footer mt-5">
                <asp:Button ID="btnAgregar" runat="server" Text="Aceptar" OnClick="btnAgregar_Click" CssClass="btn btn-success btn-lg" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg" OnClick="btnCancel_Click"/>
            </div>
    </div>
</asp:Content>
