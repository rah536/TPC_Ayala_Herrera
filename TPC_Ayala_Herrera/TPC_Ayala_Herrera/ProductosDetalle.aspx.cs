using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Dominio;
using Negocio;


namespace TPC_Ayala_Herrera
{
    public partial class ProductosDetalle : System.Web.UI.Page
    {
       
        public List<Producto> Listaproducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //tring idProdu = Request.QueryString["id"].ToString();

            ProductoNegocio negocio = new ProductoNegocio();

            Listaproducto = negocio.listar();


        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
    }
}