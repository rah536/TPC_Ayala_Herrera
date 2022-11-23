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
            //elido en el ddl del pageload
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
                //Completo la operacion
                CompraOperacion compraOp = new CompraOperacion();
                compraOp.Proveedor = new Proveedor();
                compraOp.Proveedor.Id = IdProveedor;

                listaProveedor = listaProveedor.FindAll(x => x.IdProveedor == IdProveedor);
                foreach (Proveedor item in listaProveedor)
                {
                    compraOp.Proveedor.RazonSocial = item.RazonSocial;
                    compraOp.Proveedor.Cuit = item.Cuit;
                    compraOp.Proveedor.Domicilio = item.Domicilio;
                }
                compraOp.FechaCompra = DateTime.Now;

                //completo el detalle
                CompraOperacionDetalle compraOpDetalle = new CompraOperacionDetalle();
                compraOpDetalle.Producto = new Producto();
                IdProducto = int.Parse(ddlProducto.SelectedItem.Value);
                compraOpDetalle.Producto.Id = IdProducto;

                listaProducto = listaProducto.FindAll(x => x.Id == IdProducto);
                foreach (Producto item in listaProducto)
                {
                    compraOpDetalle.Producto.Codigo = item.Codigo;
                    compraOpDetalle.Producto.Descripcion = item.Descripcion;
                    compraOpDetalle.Producto.CostoUnidad = item.CostoUnidad;
                }

                compraOpDetalle.Cantidad = int.Parse(txtCantidadIngreso.Text);
                compraOpDetalle.SubTotal = float.Parse(txtCostoUnidad.Text);
                opDetalles.Add(compraOpDetalle);

                gvCompras.DataSource = opDetalles;
                gvCompras.DataBind();

                //acumulo los subtotal en variable TotalaPagar
                TotalaPagar += (compraOpDetalle.Cantidad * compraOpDetalle.SubTotal);
                lblTotal.Text = TotalaPagar.ToString();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Guardar en base la operacion y el detalle
            //Actualizar stock, porcentaje ganancia y costo de producto
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}