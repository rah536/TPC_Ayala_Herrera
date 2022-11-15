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
            <div class="card-body col-3 m-auto">
                <div class="mb-6">

                    <asp:Label ID="lvRazonSocial" runat="server" Text="Razon Social:   " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="tbRazonSocial" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>

                <div class="mb-6">

                    <asp:Label ID="lvNombre" runat="server" Text="Nombre :   "></asp:Label>
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>
                <div class="mb-6">

                    <asp:Label ID="lvApellido" runat="server" Text="Apellido :   "></asp:Label>
                    <asp:TextBox ID="tbApellido" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>
                <div class="mb-6">

                    <asp:Label ID="lbDni" runat="server" Text="DNI :   "></asp:Label>
                    <asp:TextBox ID="tbDni" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>
                <div class="mb-6">

                    <asp:Label ID="lbCuit" runat="server" Text="CUIT :   "></asp:Label>
                    <asp:TextBox ID="tbCuit" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>
                <div class="mb-6">

                    <asp:Label ID="lbDomicilio" runat="server" Text="Domicilio :   "></asp:Label>
                    <asp:TextBox ID="tbDomicilio" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>
                <div class="mb-6">

                    <asp:Label ID="lbMail" runat="server" Text="Mail :   "></asp:Label>
                    <asp:TextBox ID="tbMail" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>
                <div class="mb-6">

                    <asp:Label ID="lbTelefono" runat="server" Text="Telefono :   "></asp:Label>
                    <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control"></asp:TextBox><br>
                </div>



                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-success btn-lg" />





            </div>

        </div>


        <div class="card-footer">
        </div>
    </div>
</asp:Content>
