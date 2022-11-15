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
    public partial class ProductosAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            if(!IsPostBack)
            {
                try
                {
                    //cargo los ddl siempre (si agrego o modifico producto)
                    ddlProveedor.DataSource = proveedorNegocio.listar();
                    ddlProveedor.DataTextField = "RazonSocial";
                    ddlProveedor.DataValueField = "IdProveedor";
                    ddlProveedor.DataBind();

                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }
                catch (Exception ex)
                {
                    //mensaje de error
                    throw ex;
                }
            }
            


            //precargo los textbox y precargo ddl porque quiero MODIFICAR PRODUCTO
            if (Request.QueryString["id"] != null && !IsPostBack) //Si el link viene con un id, cargo los datos en los textbox
            {

                ProductoNegocio productoNegocio = new ProductoNegocio();
                List<Producto> producto = productoNegocio.listar();

                foreach (Producto item in producto) //recorro la lista de Productos para encontrar el producto con el id que es igual al id del link
                {
                    if (item.Id.ToString() == Request.QueryString["id"].ToString())
                    {
                        txtCodigo.Text = item.Codigo.ToString();
                        txtDescripcion.Text = item.Descripcion;
                        txtCantidadIngreso.Visible = false; //esto solo se ve al agregar, no al modificar
                        txtCostoUnidad.Text = item.CostoUnidad.ToString();
                        txtStockActual.Text = item.StockActual.ToString();
                        txtStockMinimo.Text = item.StockMinimo.ToString();
                        txtPorcentajeGanancia.Text = item.PorcentajeGanancia.ToString();
                        txtUrlImagen.Text = item.UrlImagen;

                        //falta precargar los ddl
                        //ddlProveedor.SelectedValue = item.Proveedor.IdProveedor.ToString();

                    }
                }
            }
            else
            {
                txtStockActual.Visible = false;  //al DAR DE ALTA el stockACtual lo
                lblStockActual.Visible = false; //manejamos con la var cantidad de ingreso
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();

            producto.Codigo = int.Parse(txtCodigo.Text);
            producto.Descripcion = txtDescripcion.Text;

            producto.Proveedor = new Proveedor();
            producto.Proveedor.Id = int.Parse(ddlProveedor.SelectedValue);

            producto.Marca = new Marca();
            producto.Marca.Id = int.Parse(ddlMarca.SelectedValue);

            producto.Categoria = new Categoria();
            producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

            producto.CostoUnidad = float.Parse(txtCostoUnidad.Text);


            producto.StockMinimo = int.Parse(txtStockMinimo.Text);


            producto.PorcentajeGanancia = float.Parse(txtPorcentajeGanancia.Text);
            producto.UrlImagen = txtUrlImagen.Text;

            if (Request.QueryString["id"] != null) //Modificar
            {
                try
                {
                    producto.StockActual = int.Parse(txtStockActual.Text);
                    producto.Id = int.Parse(Request.QueryString["id"]);
                    productoNegocio.modificar(producto);
                    //Añadir cartel aclarando si se pudo o no modificar registro
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Agregar cartel de error
                }
            }

            else
            {
                try
                {
                    //cantidad de ingreso existe solo si damos de alta productos
                    int CantidadIngreso = int.Parse(txtCantidadIngreso.Text);
                    //agregar
                    productoNegocio.agregar(producto, CantidadIngreso);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
    }
}