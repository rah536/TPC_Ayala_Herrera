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

            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Debes ser administrador para acceder a esta pagina.");
                Response.Redirect("Error.aspx");

            }



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
                empleado.Admin = ckbAdmin.Checked;


                int id = usuarioNegocio.insertarNuevo(empleado);


                //  Response.Redirect("default.aspx");
                PanelAltaUsuarioOk.Visible = true;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());

            }
        }

        protected void btnCerrarAltaUsuarioOk_Click(object sender, EventArgs e)
        {
            PanelAltaUsuarioOk.Visible = false;
            Response.Redirect("Default.aspx", false);
        }
    }
}