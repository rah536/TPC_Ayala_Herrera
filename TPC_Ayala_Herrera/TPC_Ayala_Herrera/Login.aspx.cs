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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {

                usuario.Email = txtmailUsuario.Text;
                usuario.Password = txtContaseña.Text;
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx",false);
                }
                else {
                    Session.Add("error", "Email o Password incorrecto!!!");
                    Response.Redirect("Error.aspx",false);
                        }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }


        }











        /*
protected void btnIngresar_Click(object sender, EventArgs e)
{
   Usuario usuario;
   UsuarioNegocio negocio = new UsuarioNegocio();

   try
   {
       usuario = new Usuario(txtUsuario.Text, txtContaseña.Text, false);
       if (negocio.Loguear(usuario))
       {
           Session.Add("usuario", usuario);
           Response.Redirect("Default.aspx");


       }
       else
       {
           Session.Add("error", "user o pass incorrectos");
           Response.Redirect("Error.aspx", false);

       }

   }
   catch (Exception ex)
   {
       Session.Add("error", ex.ToString());
       throw;
   }


}*/
    }
}