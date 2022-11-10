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
        protected void Page_Load(object sender, EventArgs e)
        {


            ProveedorNegocio proveedornegocio    = new ProveedorNegocio();
            gvProveedor.DataSource = proveedornegocio.listar();
            gvProveedor.DataBind();

        }

        protected void btnAltaProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProveedoresAlta.aspx",false);





        }
    }
}