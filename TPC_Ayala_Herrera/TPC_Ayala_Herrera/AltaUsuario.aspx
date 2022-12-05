<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TPC_Ayala_Herrera.AltaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="card text-center">


            <div class="card-body col-3 m-auto">
                <div class="mb-6">

                     <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ></asp:TextBox>
                      <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ></asp:TextBox>
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtContaseña" runat="server"  CssClass="form-control" ></asp:TextBox>.
                    </br>
                    <asp:Button ID="btnAltaUsuario"  runat="server" Text="Alta" OnClick="btnAltaUsuario_Click"  CssClass="btn btn-success" />

                </div>

            </div>
        </div>













</asp:Content>
