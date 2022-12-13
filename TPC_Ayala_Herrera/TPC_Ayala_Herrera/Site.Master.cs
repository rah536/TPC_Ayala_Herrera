using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_Ayala_Herrera
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Default || Page is Error)) {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }



        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {


                Session.Add("error", ex.ToString());
            }


        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }



        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");

        }
    }
}