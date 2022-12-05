using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Ayala_Herrera
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario empleado = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();   

                empleado.Email = (string)txtEmail.Text;
                empleado.Nombre = (string)txtNombre.Text;
                empleado.Apellido = (string)txtContaseña.Text;
                empleado.Password = (string)txtContaseña.Text;
                empleado.Admin = false;


                int id = usuarioNegocio.insertarNuevo(empleado);


              //  Response.Redirect("default.aspx");
                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());

            }
        }
    }
}