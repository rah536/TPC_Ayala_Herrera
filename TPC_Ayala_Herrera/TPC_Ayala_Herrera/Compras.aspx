<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Ayala_Herrera.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card text-center">
        <div class="card-header">
            <h3>Formulario de Compra</h3>
        </div>
        <div class="card-body fs-5">
            <div class="form-text col-6 m-auto">
                <div class="m-4 accordion-button fs-5">
                    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
                    <asp:DropDownList ID="ddlProveedor" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>

                    <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label>
                    <asp:DropDownList ID="ddlProducto" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList><br />
                </div>

                <div class="border border-5 rounded-end alert">
                    <asp:Label ID="lblCostoUnidad" runat="server" Text="Ingrese el Costo por unidad"></asp:Label> 
                    <asp:TextBox ID="txtCostoUnidad" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                    <asp:Label ID="lblCantidadIngreso" runat="server" Text="Cantidad de productos a ingresar"></asp:Label> 
                    <asp:TextBox ID="txtCantidadIngreso" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                    <asp:Label ID="lblStockMinimo" runat="server" Text="Ingrese el stock minimo de productos"></asp:Label> 
                    <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-text"></asp:TextBox> <br />
                
                    <asp:Label ID="lblPorcentajeGanancia" runat="server" Text="Ingrese el % de ganancia por unidad"></asp:Label> 
                    <asp:TextBox ID="txtPorcentajeGanancia" runat="server" CssClass="form-text"></asp:TextBox> <br />
                </div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-dark btn-lg" OnClick="btnAgregar_Click"  /> <br />
            </div>

            <div class="col-6 m-auto">
            <asp:GridView ID="gvCompras" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Producto.Codigo"/>
                    <asp:BoundField HeaderText="Descripción" DataField="Producto.Descripcion"/>
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Sub_Total" DataField="SubTotal" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
                                
                <div class="row">
                    <div class="col-10 border border-3 text-bg-warning">
                        <asp:Label ID="lblTotalTexto" CssClass="form-text" runat="server" Text="Total $"></asp:Label>
                        <asp:Label ID="lblTotal" CssClass="form-text" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnVaciar" runat="server" Text="Vaciar" CssClass="btn btn-dark btn-lg" />
                    </div>
                </div>
            </div>

        </div>

        <asp:Panel ID="PanelAgregadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelAgregadoOk" runat="server" Text="Compra efectuada con éxito"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelAgregadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar" OnClick="btnCerrarPanelAgregadoOk_Click" />
        </asp:Panel>


        <div class="card-footer mt-5">
            <asp:Button ID="btnAceptar" runat="server" Text="Confirmar Compra" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click"  />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Compra" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
