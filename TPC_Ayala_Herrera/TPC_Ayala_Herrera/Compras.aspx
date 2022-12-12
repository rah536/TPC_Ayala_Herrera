<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Ayala_Herrera.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card text-center">
        <div class="card-header">
            <h3>Compra</h3>
        </div>

        <div class="card-body fs-5">
             <div>
                <p>
                  <button class="btn btn-dark btn-lg" type="button" data-bs-toggle="collapse" data-bs-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                    Ver historial de compras
                  </button>
                </p>
                <div class="collapse" id="collapseExample">
                  <div class="card card-body col-6 m-auto">
                      <asp:GridView ID="gvHistorialCompras" OnRowEditing="gvHistorialCompras_RowEditing" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Id Compra" DataField="Id"/>
                            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.RazonSocial"/>
                            <asp:BoundField HeaderText="Fecha Compra" DataField="FechaCompra" />
                            <asp:BoundField HeaderText="Total" DataField="Total" />
                            <asp:CommandField ShowEditButton="true" EditText="Detalle de Compra" ControlStyle-CssClass="btn btn-warning" HeaderText="Detalle" />
                        </Columns>
                      </asp:GridView>
                  </div>
                </div>
            </div>


            <br />
            <h4>Formulario de Compra</h4>
            <div class="form-text col-6 m-auto">
                <div class="m-4 accordion-button fs-5">
                    <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
                    <asp:DropDownList ID="ddlProveedor" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>

                    <asp:Label ID="lblProducto" runat="server" Text="Producto"></asp:Label>
                    <asp:DropDownList ID="ddlProducto" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList><br />
                </div>

                <div class="border border-5 rounded-end alert">
                    <div class="mb-1">
                        <asp:Label ID="lblCostoUnidad" runat="server" Text="Ingrese el Costo por unidad"></asp:Label> 
                        <asp:TextBox ID="txtCostoUnidad" runat="server" CssClass="form-text"></asp:TextBox> <br />
                        <asp:RequiredFieldValidator ID="rfvCostoUnidad" runat="server" ErrorMessage="Ingrese Costo Unidad" ControlToValidate="txtCostoUnidad" style="color:red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCostoUnidad" runat="server" ErrorMessage="Ingresar solo números" ControlToValidate="txtCostoUnidad" ValidationExpression="^\d+$" style="color:red;"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblCantidadIngreso" runat="server" Text="Cantidad de productos a ingresar"></asp:Label> 
                        <asp:TextBox ID="txtCantidadIngreso" runat="server" CssClass="form-text"></asp:TextBox> <br />
                        <asp:RequiredFieldValidator ID="rfvCantidadIngreso" runat="server" ErrorMessage="Ingrese Cantidad Stock" ControlToValidate="txtCantidadIngreso" style="color:red;"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCantidadIngreso" runat="server" ErrorMessage="Ingresar solo números" ControlToValidate="txtCantidadIngreso" ValidationExpression="^\d+$" style="color:red;"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblStockMinimo" Visible="false" runat="server" Text="Ingrese el stock minimo de productos"></asp:Label> 
                        <asp:TextBox ID="txtStockMinimo" Visible="false" runat="server" CssClass="form-text"></asp:TextBox>
                    </div>
                    <div class="mb-1">
                        <asp:Label ID="lblPorcentajeGanancia" Visible="false" runat="server" Text="Ingrese el % de ganancia por unidad"></asp:Label> 
                        <asp:TextBox ID="txtPorcentajeGanancia" Visible="false" runat="server" CssClass="form-text"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-dark btn-lg" OnClick="btnAgregar_Click"  /> <br />
                <br />
            </div>

            <div class="col-6 m-auto">
            <asp:GridView ID="gvCompras" OnRowDeleting="gvCompras_RowDeleting" CssClass="table table-striped" AutoGenerateColumns="false" runat="server">
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
                        <asp:Button ID="btnVaciarGrilla" runat="server" Text="Vaciar" CssClass="btn btn-dark btn-lg" OnClick="btnVaciarGrilla_Click" />
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
