<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TPC_Ayala_Herrera.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>
        <div class="card text-center">

            <div class="card-header">
                <img src="img/login2.png" alt="logoLogin" height="100" width="100" /><br />
                <h3>Alta de usuario</h3>
            </div>

            <div class="card-body col-3 m-auto">
                <div class="mb-6">

                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtContaseña" runat="server" CssClass="form-control"></asp:TextBox>.
                   <br />

                    <%--                   
                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                    --%>
                    <asp:Label ID="lblAdmin" runat="server" Text="Administrador " CssClass="form-check-label"></asp:Label>


                    <asp:CheckBox ID="ckbAdmin" runat="server" CssClass="form-check-input" />

                    <br />
                    <br />
                    <asp:Button ID="btnAltaUsuario" runat="server" Text="Alta" OnClick="btnAltaUsuario_Click" CssClass="btn btn-success" />

                </div>

            </div>
            <asp:Panel ID="PanelAltaUsuarioOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblAltaUsuarioOk" runat="server" Text="El usuario ha sido dado de alta"></asp:Label></h5>
            <asp:Button ID="btnCerrarAltaUsuarioOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarAltaUsuarioOk_Click"/>
            </asp:Panel>
        </div>
    </div>













</asp:Content>
