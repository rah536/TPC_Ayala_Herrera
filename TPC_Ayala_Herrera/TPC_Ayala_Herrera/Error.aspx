<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Ayala_Herrera.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="card-body col-6 m-auto">
        <div>
            <h1>Hubo un problema</h1>

        </div>
        <div>

            <asp:Label Text="" ID="lblMensaje" runat="server" />

        </div>

    </div>



</asp:Content>
