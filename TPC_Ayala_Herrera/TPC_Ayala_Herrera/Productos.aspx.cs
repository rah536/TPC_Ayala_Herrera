using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Ayala_Herrera
{
    public partial class Productos : System.Web.UI.Page
    {
        static string id2; //variable para el panel de eliminar

        protected void Page_Load(object sender, EventArgs e)
        {
          
            ProductoNegocio productoNegocio = new ProductoNegocio();
            gvProductos.DataSource = productoNegocio.listar();
            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }
            else { 
            var id = gvProductos.SelectedRow.Cells[0].Text;
            Response.Redirect("ProductosAlta.aspx?id=" + id, false);
            }
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }

            else { 
            Panel1.Visible = true;
            var id = gvProductos.Rows[e.RowIndex].Cells[0].Text;
            id2 = id;
            }
        }

        protected void btnPanelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                productoNegocio.eliminar(int.Parse(id2));
                Panel1.Visible = false;
                //Actualiza la grilla al eliminar
                gvProductos.DataSource = productoNegocio.listar();
                gvProductos.DataBind();
                //mensaje borrado ok
                PanelEliminadoOk.Visible = true;
            }
            catch (Exception ex)
            {
                Panel1.Visible = false;
                throw ex;
                //mensaje de error
            }
        }

        protected void btnPanelCancelar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void btnAltaProducto_Click(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }
            Response.Redirect("ProductosAlta.aspx", false);
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Redirigir a pagina para ver detalle
            var id = gvProductos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("ProductosDetalle.aspx?id=" + id, false);
        }

        protected void btnCerrarPanelEliminadoOk_Click(object sender, EventArgs e)
        {
            PanelEliminadoOk.Visible = false;
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaFiltrada = productoNegocio.listar();
            if (txtFiltro.Text != "")
            {
                listaFiltrada = listaFiltrada.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Proveedor.RazonSocial.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Codigo.ToString().Contains(txtFiltro.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            }
            gvProductos.DataSource = listaFiltrada;
            gvProductos.DataBind();
        }

        protected void ibtnBorrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            gvProductos.DataSource = productoNegocio.listar();
            gvProductos.DataBind();
            txtFiltro.Text = "";
        }
    }




}