using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Ayala_Herrera
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}