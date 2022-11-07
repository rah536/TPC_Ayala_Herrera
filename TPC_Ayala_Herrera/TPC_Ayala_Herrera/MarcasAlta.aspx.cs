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
    public partial class MarcasAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                marcaNegocio.agregar(txtDescripcion.Text);
                //Agregar cartel aclarando si se pudo o no agregar registro
            }
            catch (Exception ex)
            {
                throw ex;
                //Agregar cartel de error
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx", false);
        }
    }
}