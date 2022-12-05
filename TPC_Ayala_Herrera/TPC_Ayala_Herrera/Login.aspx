<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Ayala_Herrera.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="card text-center">


            <div class="card-body col-3 m-auto">
                <div class="mb-6">

                    <asp:Label ID="lblMailUsuario" runat="server" Text="Email Usuario" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtmailUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lbContraseña" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtContaseña" runat="server" type="password" CssClass="form-control" ></asp:TextBox>
                    </br>
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-success" />

                </div>

            </div>
        </div>





    </div>


</asp:Content>
