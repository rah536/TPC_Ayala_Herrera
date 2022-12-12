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
    public partial class Compras : System.Web.UI.Page
    {
        static int IdProveedor;
        static int IdProducto;
        static List<CompraOperacionDetalle> opDetalles = new List<CompraOperacionDetalle>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();


            try
            {
                if (!IsPostBack)
                {
                    

                    ddlProveedor.DataSource = proveedorNegocio.listar();
                    ddlProveedor.DataTextField = "RazonSocial";
                    ddlProveedor.DataValueField = "IdProveedor";
                    ddlProveedor.DataBind();

                    CompraNegocio compraNegocio = new CompraNegocio();
                    gvHistorialCompras.DataSource = compraNegocio.listarHistorial();
                    gvHistorialCompras.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lleno ddl de producto, en base al proveedor
            //elegido
            IdProveedor = int.Parse(ddlProveedor.SelectedItem.Value);
            int id = int.Parse(ddlProveedor.SelectedItem.Value);

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaProductos = productoNegocio.listar();
            ddlProducto.DataSource = listaProductos.FindAll(x => x.Proveedor.Id == id);
            ddlProducto.DataTextField = "Descripcion";
            ddlProducto.DataValueField = "Id";
            ddlProducto.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            gvCompras.DataSource = null;
            gvCompras.DataBind();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            List<Proveedor> listaProveedor = proveedorNegocio.listar();

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaProducto = productoNegocio.listar();

            if (IdProveedor == 0)
            {
                //Validacion Elige proveedor
            }
            else
            {
                //Comienzo a completar los datos de la CompraOperacion

                CompraOperacion compraOp = new CompraOperacion();
                compraOp.Proveedor = new Proveedor();
                compraOp.Proveedor.Id = IdProveedor;
                //IdProveedor lo obtengo de lo que elegi en el primer ddl

                //completo el detalle
                CompraOperacionDetalle compraOpDetalle = new CompraOperacionDetalle();
                compraOpDetalle.Producto = new Producto();
                IdProducto = int.Parse(ddlProducto.SelectedItem.Value);
                compraOpDetalle.Producto.Id = IdProducto;
                //recorro el listado de productos, y encuentro el producto
                //que coincida con el Id que obtuve en el segundo ddl

                listaProducto = listaProducto.FindAll(x => x.Id == IdProducto);
                foreach (Producto item in listaProducto)
                {
                    compraOpDetalle.Producto.Codigo = item.Codigo;
                    compraOpDetalle.Producto.Descripcion = item.Descripcion;
                    compraOpDetalle.Producto.CostoUnidad = item.CostoUnidad;
                }
                //compraOpDetalle.Producto.PorcentajeGanancia = float.Parse(txtPorcentajeGanancia.Text);
                //compraOpDetalle.Producto.StockMinimo = int.Parse(txtStockMinimo.Text);
                compraOpDetalle.Producto.StockActual = int.Parse(txtCantidadIngreso.Text);
                compraOpDetalle.Producto.CostoUnidad = float.Parse(txtCostoUnidad.Text);
                compraOpDetalle.Cantidad = int.Parse(txtCantidadIngreso.Text);
                compraOpDetalle.SubTotal = float.Parse(txtCostoUnidad.Text);
                //cargo las propiedades de la instancia de
                //CompraOperacionDetalle y guardo en list (opDetalles)
                opDetalles.Add(compraOpDetalle);
                //luego de cargar el list, se lo asigno al gv
                gvCompras.DataSource = opDetalles;
                gvCompras.DataBind();

                //acumulo los subtotal en variable TotalaPagar
                ActualizarValores(true);

                //Vacio los textbox
                VaciarTxt();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Completo la operacion para guardar en db
            CompraOperacion compraOp = new CompraOperacion();
            compraOp.Proveedor = new Proveedor();
            compraOp.Proveedor.Id = IdProveedor;
            compraOp.Total = ActualizarValores(true);
            compraOp.FechaCompra = DateTime.Now;

            //Completo el detalle para guardar en db
            try
            {
                //agregamos la Operacion
                CompraNegocio compraNegocio = new CompraNegocio();
                if (compraNegocio.agregar(compraOp))
                {
                    //rescatamos el Id de la operacion recientemente guardada
                    int IdOp = compraNegocio.rescatarIdOperacion();
                    //agregamos detalles de la Operacion
                    compraNegocio.agregarDetalle(opDetalles, IdOp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Actualizar stock, porcentaje ganancia y costo de producto
            ProductoNegocio productoNegocio = new ProductoNegocio();
            productoNegocio.actualizarStock(opDetalles);
            PanelAgregadoOk.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnCerrarPanelAgregadoOk_Click(object sender, EventArgs e)
        {
            PanelAgregadoOk.Visible = false;
            Response.Redirect("Compras.aspx", false);
        }

        protected void VaciarTxt()
        {
            txtCantidadIngreso.Text = "0";
            txtCostoUnidad.Text = "0";
            txtPorcentajeGanancia.Text = "0";
            txtStockMinimo.Text = "0";
        }

        protected void gvCompras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //elimina filas de la grilla
            int id = gvCompras.Rows[e.RowIndex].RowIndex;
            opDetalles.RemoveAt(id);
            gvCompras.DataSource = opDetalles;
            gvCompras.DataBind();
            ActualizarValores(true);
        }

        protected void btnVaciarGrilla_Click(object sender, EventArgs e)
        {
            opDetalles.Clear();
            gvCompras.DataSource = opDetalles;
            gvCompras.DataBind();
            ActualizarValores(false);
        }

        protected float ActualizarValores(bool T)
        {
            float TotalaPagar = 0;

            if (T == true)
            {
                foreach (CompraOperacionDetalle item in opDetalles)
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

        protected void gvHistorialCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Redirigir a pagina para ver detalle
            var id = gvHistorialCompras.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("ComprasDetalle.aspx?id=" + id, false);
        }
    }
}