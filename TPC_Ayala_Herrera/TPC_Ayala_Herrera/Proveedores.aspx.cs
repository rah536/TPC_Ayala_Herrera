using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Ayala_Herrera
{
    public partial class Proveedores : System.Web.UI.Page
    {
        static string id2; //variable para el panel de eliminar

        protected void Page_Load(object sender, EventArgs e)
        {


            ProveedorNegocio proveedornegocio = new ProveedorNegocio();
            gvProveedor.DataSource = proveedornegocio.listar();
            gvProveedor.DataBind();

        }
        protected void gvProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gvProveedor.SelectedRow.Cells[0].Text;
            //Redirigir a pagina para modificar
            Response.Redirect("ProveedoresAlta.aspx?id=" + id, false);
        }
        protected void gvProveedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Panel1.Visible = true;
            var id = gvProveedor.Rows[e.RowIndex].Cells[0].Text;
            id2 = id;
        }

        public void btnPanelAceptarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                proveedorNegocio.eliminar(int.Parse(id2));
                Panel1.Visible = false;
                gvProveedor.DataSource = proveedorNegocio.listar();
                gvProveedor.DataBind();
            }
            catch (Exception ex)
            {
                Panel1.Visible = false;
                throw ex;
                //mensaje de error
            }


        }

        protected void btnAltaProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresAlta.aspx", false);


        }


        public void btnPanelCancelarProveedor_Click(object sender, EventArgs e)
        {


            Panel1.Visible = false;



        }








    }
}