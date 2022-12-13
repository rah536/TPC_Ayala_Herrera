<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Ayala_Herrera.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card text-center">
        <div class="card-header">
            <img src="img/venta.png" alt="logoVenta" height="120" width="120" /><br />
            <h3>Ventas</h3>
        </div>
        <div class="card-body">
            <div>
                <p>
                  <button class="btn btn-dark btn-lg" type="button" data-bs-toggle="collapse" data-bs-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                    Ver historial de Ventas
                  </button>
                </p>
                <div class="collapse" id="collapseExample">
                  <div class="card card-body col-6 m-auto">
                      <asp:GridView ID="gvHistorialVentas" OnRowEditing="gvHistorialVentas_RowEditing" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Id Venta" DataField="Id"/>
                            <asp:BoundField HeaderText="Número de Cliente" DataField="Cliente.NumCliente"/>
                            <asp:BoundField HeaderText="Nombre" DataField="Cliente.Nombre"/>
                            <asp:BoundField HeaderText="Apellido" DataField="Cliente.Apellido"/>
                            <asp:BoundField HeaderText="Fecha Venta" DataField="FechaVenta" />
                            <asp:BoundField HeaderText="Total" DataField="Total" />
                            <asp:CommandField ShowEditButton="true" EditText="Detalle de Venta" ControlStyle-CssClass="btn btn-warning" HeaderText="Detalle" />
                        </Columns>
                      </asp:GridView>
                  </div>
                </div>
            </div>
            <br />

            <h4>Formulario de Venta</h4>
            <div class="form-text col-6 m-auto">
                <div class="m-4 accordion-button fs-5">
                    <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>
                    <asp:DropDownList ID="ddlCliente" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>

                    <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label>
                    <asp:DropDownList ID="ddlProducto" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList><br />
                
                    <asp:Label ID="lblStock" runat="server" Text="Stock Disponible: "></asp:Label>
                    <asp:TextBox ID="txtStock" ReadOnly="true" runat="server" Text="0" Width="61px"></asp:TextBox>
                    
                    <asp:Label ID="lblPorcentajeGanancia" runat="server" Text="% Ganancia: "></asp:Label>
                    <asp:TextBox ID="txtPorcentajeGanancia" ReadOnly="true" runat="server" Text="0" Width="61px"></asp:TextBox>
                </div>

                <div class="border border-5 rounded-end alert">
                    <div class="mb-1">
                        <asp:Label ID="lblCantidadProductos" runat="server" Text="Cantidad de Productos: "></asp:Label>
                        <asp:TextBox ID="txtCantidadProductos" visible="false" runat="server" Text="0"></asp:TextBox>
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblCantProd" runat="server" Text="Cantidad de Productos Disponibles: "></asp:Label>
                        <asp:DropDownList ID="ddlStock" runat="server" Height="25px" Width="86px"></asp:DropDownList>
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblPrecioUnidad" runat="server" Text="Precio por cada unidad: "></asp:Label>
                        <asp:TextBox ID="txtPrecioUnidad" ReadOnly="true" runat="server" Text=""></asp:TextBox>
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblPrecioFinal" runat="server" Text="Precio Final por unidad: "></asp:Label>
                        <asp:TextBox ID="txtPrecioFinal" ReadOnly="true" runat="server" Text=""></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-dark btn-lg" OnClick="btnAgregar_Click" /> <br />
                <br />
            </div>

            <div class="col-6 m-auto">
            <asp:GridView ID="gvVentas" OnRowDeleting="gvVentas_RowDeleting" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
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
                        <asp:Button ID="btnVaciarGrilla" runat="server" Text="Vaciar" CssClass="btn btn-dark btn-lg" OnClick="btnVaciarGrilla_Click"/>
                    </div>
                </div>
            </div>

        </div>

        <asp:Panel ID="PanelAgregadoOk" visible="false" BackColor="lightgray" cssclass="modal modal-content m-auto p-3 text-center fixed-bottom position-absolute border-5 border-dark" Height="180px" Width="350px" runat="server">
            <h5><asp:Label ID="lblPanelAgregadoOk" runat="server" Text="Venta efectuada con éxito"></asp:Label></h5>
            <asp:Button ID="btnCerrarPanelAgregadoOk" CssClass="btn btn-primary mt-md-5" runat="server" Text="Cerrar"  OnClick="btnCerrarPanelAgregadoOk_Click"/>
        </asp:Panel>


        <div class="card-footer">
            <asp:Button ID="btnAceptar" runat="server" Text="Confirmar Compra" CssClass="btn btn-success btn-lg" OnClick="btnAceptar_Click"   />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Compra" CssClass="btn btn-danger btn-lg" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
