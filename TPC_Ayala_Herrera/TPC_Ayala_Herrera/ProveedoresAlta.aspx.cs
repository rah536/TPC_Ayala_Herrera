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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Proveedor aux = new Proveedor();

            aux.RazonSocial = tbRazonSocial.Text;
            aux.Nombre = tbNombre.Text;
            aux.Apellido = tbApellido.Text;
            aux.Dni = Convert.ToInt64(tbDni.Text);
            aux.Cuit = Convert.ToInt64(tbCuit.Text);
            aux.Domicilio = tbDomicilio.Text;
            aux.Mail = tbMail.Text;
            aux.Telefono = tbTelefono.Text;
            aux.Estado = Convert.ToBoolean(Convert.ToInt16(tbEstado.Text));
            aux.IdRol = Convert.ToInt16(tbIdRol.Text);






            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            proveedorNegocio.agregar(aux);
            
            




        }
    }
}