<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProveedoresAlta.aspx.cs" Inherits="TPC_Ayala_Herrera.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div class="card text-center">
        <div class="card-header">
            <h3>Listado Proveedores</h3>
             <div>
               






            </div>
        </div>
         <div class="card-body col-6 m-auto">
         


             <asp:TextBox ID="tbRazonSocial" runat="server"></asp:TextBox>
             <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>





        
             </div>
        

        <div class="card-footer">
            
        </div>
    </div>


</asp:Content>
