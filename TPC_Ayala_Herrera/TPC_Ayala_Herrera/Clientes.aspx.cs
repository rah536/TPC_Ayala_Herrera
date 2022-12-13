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
    public partial class Clientes : System.Web.UI.Page
    {
        static string id2; //variable para el panel de eliminar

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio clientenegocio = new ClienteNegocio();
            gvClientes.DataSource = clientenegocio.listar();
            gvClientes.DataBind();
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }

            else
            {
                var id = gvClientes.SelectedRow.Cells[0].Text;
                //Redirigir a pagina para modificar
                Response.Redirect("ClientesAlta.aspx?id=" + id, false);

            }
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))

            {
                Session.Add("error", "Debes ser Administrador para acceder a esta opcion.");
                Response.Redirect("Error.aspx", false);

            }

            else { 
                Panel1.Visible = true;
            var id = gvClientes.Rows[e.RowIndex].Cells[0].Text;
            id2 = id;
        }
        }

        protected void btnPanelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                clienteNegocio.eliminar(int.Parse(id2));
                Panel1.Visible = false;
                gvClientes.DataSource = clienteNegocio.listar();
                gvClientes.DataBind();
                //mensaje de eliminado con exito
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

        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientesAlta.aspx", false);
        }

        protected void btnCerrarPanelEliminadoOk_Click(object sender, EventArgs e)
        {
            PanelEliminadoOk.Visible = false;
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaFiltrada = clienteNegocio.listar();
            if (txtFiltro.Text != "")
            {
                listaFiltrada = listaFiltrada.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Apellido.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Dni.ToString().Contains(txtFiltro.Text.ToUpper()) || x.NumCliente.ToString().Contains(txtFiltro.Text.ToUpper()));
            }
            gvClientes.DataSource = listaFiltrada;
            gvClientes.DataBind();
        }

        protected void ibtnBorrarFiltro_Click(object sender, ImageClickEventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            gvClientes.DataSource = clienteNegocio.listar();
            gvClientes.DataBind();
            txtFiltro.Text = "";
        }
    }
}