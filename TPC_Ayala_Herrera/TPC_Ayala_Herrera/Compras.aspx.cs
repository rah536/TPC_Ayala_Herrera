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
        static float TotalaPagar;

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
                
                //compraOp.FechaCompra = DateTime.Now;
                //le inserto la fecha con getdate() en la query

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
                compraOpDetalle.Producto.PorcentajeGanancia = float.Parse(txtPorcentajeGanancia.Text);
                compraOpDetalle.Producto.StockMinimo = int.Parse(txtStockMinimo.Text);
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
                TotalaPagar += (compraOpDetalle.Cantidad * compraOpDetalle.SubTotal);
                lblTotal.Text = TotalaPagar.ToString();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Completo la operacion para guardar en db
            CompraOperacion compraOp = new CompraOperacion();
            compraOp.Proveedor = new Proveedor();
            compraOp.Proveedor.Id = IdProveedor;
            compraOp.Total = TotalaPagar;
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
    }
}