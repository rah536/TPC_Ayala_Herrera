<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Ayala_Herrera.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="card text-center">


            <div class="card-body col-3 m-auto">
     <div class="card-header bg-transparent">
            <img src="img/login.png" alt="logoLogin" height="100" width="100" /><br />
            <h3>Login</h3>
        </div>
                <div class="mb-6">

                    <asp:Label ID="lblMailUsuario" runat="server" Text="Email Usuario" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtmailUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="revMail" runat="server" ErrorMessage="Email invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="color:red;" ControlToValidate="txtmailUsuario"></asp:RegularExpressionValidator><br />

                    <asp:Label ID="lbContraseña" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                   
                    <asp:TextBox ID="txtContaseña" runat="server" type="password" CssClass="form-control" ></asp:TextBox>
                    </br>
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-success" />

                </div>


            </div>
             <asp:Panel ID="PanelLoginOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblLogin" runat="server" Text="Te has logueado."></asp:Label></h5>
            <asp:Button ID="btnLoginOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnLoginOk_Click" />
        </asp:Panel>

        </div>





    </div>


</asp:Content>
