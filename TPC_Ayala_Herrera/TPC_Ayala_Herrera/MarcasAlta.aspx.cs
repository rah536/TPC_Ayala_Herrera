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
            if (Request.QueryString["id"] != null && !IsPostBack) //Si el link viene con un id, cargo los datos en los textbox
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> marca = marcaNegocio.listar();

                foreach (Marca item in marca) //recorro la lista de marcas para encontrar la marca con el id que viene en el link
                {
                    if (item.Id.ToString() == Request.QueryString["id"].ToString())
                    {
                        txtDescripcion.Text = item.Descripcion;

                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = new Marca();
            if (Request.QueryString["id"] != null)
            {
                marca.Id = int.Parse(Request.QueryString["id"]);
            }
                
            marca.Descripcion = txtDescripcion.Text;


            if (Request.QueryString["id"] != null) //Modificar
            {
                try
                {
                    marcaNegocio.modificar(marca);
                    PanelModificadoOk.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Agregar cartel de error
                }
            }

            else // Agregar
            {
                try
                {
                    marcaNegocio.agregar(marca.Descripcion);
                    PanelAgregadoOk.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Agregar cartel de error
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx", false);
        }

        protected void btnCerrarPanelModificadoOk_Click(object sender, EventArgs e)
        {
            PanelModificadoOk.Visible = false;
            Response.Redirect("Marcas.aspx", false);
        }

        protected void btnCerrarPanelAgregadoOk_Click(object sender, EventArgs e)
        {
            PanelAgregadoOk.Visible = false;
            Response.Redirect("Marcas.aspx", false);
        }
    }
}