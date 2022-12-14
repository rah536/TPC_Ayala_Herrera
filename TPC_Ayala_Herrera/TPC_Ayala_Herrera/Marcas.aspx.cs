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
    public partial class Marcas : System.Web.UI.Page
    {
        static string id2; //variable para el panel de eliminar
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            gvMarcas.DataSource = marcaNegocio.listar();
            gvMarcas.DataBind();
        }

        protected void gvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }

            else
            {
                var id = gvMarcas.SelectedRow.Cells[0].Text;
                //Redirigir a pagina para modificar
                Response.Redirect("MarcasAlta.aspx?id=" + id, false);
            }
        }

        protected void gvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }

            else
            {
                Panel1.Visible = true;
                var id = gvMarcas.Rows[e.RowIndex].Cells[0].Text;
                id2 = id;
            }
        }

        protected void btnPanelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                marcaNegocio.eliminar(int.Parse(id2));
                Panel1.Visible = false;
                gvMarcas.DataSource = marcaNegocio.listar();
                gvMarcas.DataBind();
                //mensaje borrado ok
                PanelEliminadoOk.Visible = true;
            }
            catch (Exception ex)
            {
                Panel1.Visible = false;
                throw ex;
                //mensaje de error
            }
        }

        protected void btnPanelCancelar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void btnAltaMarca_Click(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }

            else
            {
                Response.Redirect("MarcasAlta.aspx", false);
            }
        }

        protected void btnCerrarPanelEliminadoOk_Click(object sender, EventArgs e)
        {
            PanelEliminadoOk.Visible = false;
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marca> listaFiltrada = marcaNegocio.listar();
            if (txtFiltro.Text != "")
            {
                listaFiltrada = listaFiltrada.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            }
            gvMarcas.DataSource = listaFiltrada;
            gvMarcas.DataBind();
        }

        protected void ibtnBorrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            gvMarcas.DataSource = marcaNegocio.listar();
            gvMarcas.DataBind();
            txtFiltro.Text = "";
        }
    }
}