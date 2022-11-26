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
            if (Session["usuario"] == null) {


                Session.Add("error", "debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            
            }
            ProductoNegocio productoNegocio = new ProductoNegocio();
            gvProductos.DataSource = productoNegocio.listar();
            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gvProductos.SelectedRow.Cells[0].Text;
            Response.Redirect("ProductosAlta.aspx?id=" + id, false);
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Panel1.Visible = true;
            var id = gvProductos.Rows[e.RowIndex].Cells[0].Text;
            id2 = id;
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
    }




}