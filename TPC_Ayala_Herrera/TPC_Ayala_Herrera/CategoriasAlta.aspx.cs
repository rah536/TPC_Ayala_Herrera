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
    public partial class CategoriasAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Debes ser administrador para acceder a esta pagina.");
                Response.Redirect("Error.aspx");

            }


            if (Request.QueryString["id"] != null && !IsPostBack) //Si el link viene con un id, cargo los datos en los textbox
            {

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> categoria = categoriaNegocio.listar();

                foreach (Categoria item in categoria) //recorro la lista de Categoria para encontrar la categoria con el id que viene en el link
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
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();
            if (Request.QueryString["id"] != null)
                categoria.Id = int.Parse(Request.QueryString["id"]);

            categoria.Descripcion = txtDescripcion.Text;


            if (Request.QueryString["id"] != null) //Modificar
            {
                categoriaNegocio.modificar(categoria);
                //Añadir cartel aclarando si se pudo o no modificar registro
                PanelModificadoOk.Visible = true;
            }

            else // Agregar
            {
                try
                {
                    categoriaNegocio.agregar(categoria.Descripcion);
                    //Añadir cartel aclarando si se pudo o no agregar registro
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
            Response.Redirect("Categorias.aspx", false);
        }

        protected void btnCerrarPanelModificadoOk_Click(object sender, EventArgs e)
        {
            PanelModificadoOk.Visible = false;
            Response.Redirect("Categorias.aspx", false);
        }

        protected void btnCerrarPanelAgregadoOk_Click(object sender, EventArgs e)
        {
            PanelAgregadoOk.Visible = false;
            Response.Redirect("Categorias.aspx", false);
        }
    }
}