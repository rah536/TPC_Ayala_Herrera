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
    public partial class Categorias : System.Web.UI.Page
    {
        static string id2; //variable para el panel de eliminar
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            gvCategorias.DataSource = categoriaNegocio.listar();
            gvCategorias.DataBind();
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gvCategorias.SelectedRow.Cells[0].Text;
            //Redirigir a pagina para modificar
            Response.Redirect("CategoriasAlta.aspx?id=" + id, false);
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Panel1.Visible = true;
            var id = gvCategorias.Rows[e.RowIndex].Cells[0].Text;
            id2 = id;
        }

        protected void btnPanelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categoriaNegocio.eliminar(int.Parse(id2));
                Panel1.Visible = false;
                gvCategorias.DataSource = categoriaNegocio.listar();
                gvCategorias.DataBind();
                //mensaje de borrado con exito
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

        protected void btnAltaCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasAlta.aspx", false);
        }

        protected void btnCerrarPanelEliminadoOk_Click(object sender, EventArgs e)
        {
            PanelEliminadoOk.Visible = false;
        }
    }
}