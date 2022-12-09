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
    public partial class VentasDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                string id = Request.QueryString["id"].ToString();
                VentaNegocio vNegocio = new VentaNegocio();
                gvVentasDetalle.DataSource = vNegocio.listarDetalle(id);
                gvVentasDetalle.DataBind();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx", false);
        }
    }
}