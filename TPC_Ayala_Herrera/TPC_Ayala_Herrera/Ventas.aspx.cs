using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Ayala_Herrera
{
    public partial class Ventas : System.Web.UI.Page
    {
        static int IdProducto;
        static int IdCliente;
        static List<VentaOperacionDetalle> opDetalles = new List<VentaOperacionDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            if (!IsPostBack)
            {
                ddlCliente.DataSource = clienteNegocio.listar();
                ddlCliente.DataTextField = "Apellido";
                ddlCliente.DataValueField = "Id";
                ddlCliente.DataBind();

                ddlProducto.DataSource = productoNegocio.listar();
                ddlProducto.DataTextField = "Descripcion";
                ddlProducto.DataValueField = "Id";
                ddlProducto.DataBind();

                VentaNegocio vNegocio = new VentaNegocio();
                gvHistorialVentas.DataSource = vNegocio.listarHistorial();
                gvHistorialVentas.DataBind();
            }
            IdCliente = int.Parse(ddlCliente.SelectedItem.Value);
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdProducto = int.Parse(ddlProducto.SelectedItem.Value);

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaProductos = productoNegocio.listar();
            listaProductos = listaProductos.FindAll(x => x.Id == IdProducto);
            foreach (Producto item in listaProductos)
            {
                txtStock.Text = item.StockActual.ToString();
                txtPorcentajeGanancia.Text = item.PorcentajeGanancia.ToString();
                txtPrecioUnidad.Text = item.CostoUnidad.ToString();
                float precioFinal = item.PorcentajeGanancia * item.CostoUnidad;
                txtPrecioFinal.Text = precioFinal.ToString();
            }

            if (int.Parse(txtStock.Text) <= 0)
            {
                txtCantidadProductos.ReadOnly = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaCliente = clienteNegocio.listar();

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaProducto = productoNegocio.listar();

            /*VentaOperacion ventaOperacion= new VentaOperacion();
            ventaOperacion.Cliente = new Cliente();
            ventaOperacion.Cliente.Id = IdCliente;*/
            //IdCliente lo obtengo de lo que elegi en el primer ddl

            //Comienzo a completar los detalles de la Venta
            VentaOperacionDetalle vDetalle = new VentaOperacionDetalle();
            vDetalle.Producto = new Producto();
            vDetalle.Producto.Id = IdProducto;
            //recorro el listado de productos, y encuentro el producto
            //que coincida con el Id que obtuve en el segundo ddl
            listaProducto = listaProducto.FindAll(x => x.Id == IdProducto);
            foreach (Producto item in listaProducto)
            {
                vDetalle.Producto.Codigo = item.Codigo;
                vDetalle.Producto.Descripcion = item.Descripcion;
                vDetalle.Producto.CostoUnidad = item.CostoUnidad;
            }
            vDetalle.Cantidad = int.Parse(txtCantidadProductos.Text);
            vDetalle.SubTotal = float.Parse(txtPrecioFinal.Text);

            opDetalles.Add(vDetalle);
            gvVentas.DataSource = opDetalles;
            gvVentas.DataBind();

            //acumulo los subtotal en variable TotalaPagar
            ActualizarValores(true);

            //Vacio los textbox
            VaciarTxt();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Completo la operacion para guardar en db
            VentaOperacion ventaOp = new VentaOperacion();
            ventaOp.Cliente = new Cliente();
            ventaOp.Cliente.Id = IdCliente;
            ventaOp.Total = ActualizarValores(true);
            ventaOp.FechaVenta = DateTime.Now;


            try
            {
                VentaNegocio ventaNegocio = new VentaNegocio();
                if (ventaNegocio.agregar(ventaOp))
                {
                    //rescatamos el Id de la operacion recientemente guardada
                    if (ventaNegocio.rescatarIdOperacion() > 0)
                    {
                        int IdOp = ventaNegocio.rescatarIdOperacion();
                        //agregamos detalles de la Operacion
                        ventaNegocio.agregarDetalle(opDetalles, IdOp);
                        PanelAgregadoOk.Visible = true;
                    }
                }
                else
                {
                    //mensaje de error, no se pudo guardar la compra
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Actualizar stock
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx", false);
        }

        protected void btnCerrarPanelAgregadoOk_Click(object sender, EventArgs e)
        {
            PanelAgregadoOk.Visible = false;
            Response.Redirect("Ventas.aspx", false);
        }

        protected void gvVentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = gvVentas.Rows[e.RowIndex].RowIndex;
            opDetalles.RemoveAt(id);
            gvVentas.DataSource = opDetalles;
            gvVentas.DataBind();
            ActualizarValores(true);
        }

        protected void btnVaciarGrilla_Click(object sender, EventArgs e)
        {
            opDetalles.Clear();
            gvVentas.DataSource = opDetalles;
            gvVentas.DataBind();
            ActualizarValores(false);
        }

        protected float ActualizarValores(bool T)
        {
            float TotalaPagar = 0;

            if (T == true)
            {
                foreach (VentaOperacionDetalle item in opDetalles)
                {
                    TotalaPagar += (item.Cantidad * item.SubTotal);
                }
                lblTotal.Text = TotalaPagar.ToString();

            }

            else
            {
                TotalaPagar = 0;
                lblTotal.Text = TotalaPagar.ToString();
            }

            return TotalaPagar;
        }
        protected void VaciarTxt()
        {
            txtCantidadProductos.Text = "0";
            txtStock.Text = "0";
            txtPorcentajeGanancia.Text = "0";
            txtPrecioUnidad.Text = "0";
            txtPrecioFinal.Text = "0";
        }

        protected void gvHistorialVentas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Redirigir a pagina para ver detalle
            var id = gvHistorialVentas.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("VentasDetalle.aspx?id=" + id, false);
        }
    }
}