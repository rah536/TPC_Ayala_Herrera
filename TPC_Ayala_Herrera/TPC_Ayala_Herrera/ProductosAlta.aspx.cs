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
                        txtUrlImagen.Text = item.UrlImagen;
                        txtPorcentajeGanancia.Text = item.PorcentajeGanancia.ToString();
                        txtStockMinimo.Text = item.StockMinimo.ToString();
                        ddlProveedor.SelectedValue = item.Proveedor.Id.ToString();
                        ddlMarca.SelectedValue = item.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = item.Categoria.Id.ToString();
                    }
                }
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

            //stock, % ganancia y costos, se manejan en -Compras-
            producto.CostoUnidad = 0;
            producto.StockMinimo = int.Parse(txtStockMinimo.Text);
            producto.PorcentajeGanancia = float.Parse(txtPorcentajeGanancia.Text);
            producto.UrlImagen = txtUrlImagen.Text;

            if (Request.QueryString["id"] != null) //Modificar
            {
                try
                {
                    producto.StockActual = 0;
                    producto.Id = int.Parse(Request.QueryString["id"]);
                    productoNegocio.modificar(producto);
                    PanelModificadoOk.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Agregar cartel de error
                }
            }

            else //agregar
            {
                try 
                {
                    //cantidad de ingreso existe solo si damos de alta productos
                    int CantidadIngreso = 0;
                    productoNegocio.agregar(producto, CantidadIngreso);
                    PanelAgregadoOk.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Agregar cartel de error
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }

        protected void btnCerrarPanelModificadoOk_Click(object sender, EventArgs e)
        {
            PanelModificadoOk.Visible = false;
            Response.Redirect("Productos.aspx", false);
        }

        protected void btnCerrarPanelAgregadoOk_Click(object sender, EventArgs e)
        {
            PanelAgregadoOk.Visible = false;
            Response.Redirect("Productos.aspx", false);
        }
    }
}