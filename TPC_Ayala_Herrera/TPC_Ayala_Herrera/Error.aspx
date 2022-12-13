<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Ayala_Herrera.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card-body col-6 m-auto">
        <div class="text-center">
            <div class="p-5">
                <img src="img/error.png" alt="logoError" height="200" width="250" />
            </div>
            <div>
                <h1>Hubo un problema</h1>
            </div>
        </div>
        <div>
            <h6 class="text-center">
            <asp:Label Text="" ID="lblMensaje" runat="server" />
            </h6>
        </div>

    </div>



</asp:Content>
