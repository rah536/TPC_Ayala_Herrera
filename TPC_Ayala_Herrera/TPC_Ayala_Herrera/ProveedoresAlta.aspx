<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProveedoresAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="card text-center">
        <div class="card-header">
            <h3>Datos nuevo proveedor</h3>
            <div>

                <div class="card-body fs-5">
                    <div class="d-inline-flex mt-4">
                    </div>





                </div>
            </div>
            <div class="card-body col-6 m-auto">

                <asp:Label ID="lvRazonSocial" runat="server" Text="Razon Social:   "></asp:Label>
                <asp:TextBox ID="tbRazonSocial" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lvNombre" runat="server" Text="Nombre :   "></asp:Label>
                <asp:TextBox ID="tbNombre" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lvApellido" runat="server" Text="Apellido :   "></asp:Label>
                <asp:TextBox ID="tbApellido" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbDni" runat="server" Text="DNI :   "></asp:Label>
                <asp:TextBox ID="tbDni" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbCuit" runat="server" Text="CUIT :   "></asp:Label>
                <asp:TextBox ID="tbCuit" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbDomicilio" runat="server" Text="Domicilio :   "></asp:Label>
                <asp:TextBox ID="tbDomicilio" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbMail" runat="server" Text="Mail :   "></asp:Label>
                <asp:TextBox ID="tbMail" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbTelefono" runat="server" Text="Telefono :   "></asp:Label>
                <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbEstado" runat="server" Text="Estado (0 - 1) :   "></asp:Label>
                <asp:TextBox ID="tbEstado" runat="server" CssClass="form-text"></asp:TextBox><br>
                <asp:Label ID="lbIDRol" runat="server" Text="Rol :   "></asp:Label>
                <asp:TextBox ID="tbIdRol" runat="server" CssClass="form-text"></asp:TextBox><br>



                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />





 </div>

            </div>


            <div class="card-footer">
            </div>
        </div>
</asp:Content>
