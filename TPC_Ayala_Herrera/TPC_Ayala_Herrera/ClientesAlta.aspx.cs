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
    public partial class ClientesAlta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !IsPostBack) //Si el link viene con un id, cargo los datos en los textbox
            {

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                List<Cliente> cliente = clienteNegocio.listar();

                foreach (Cliente item in cliente) //recorro la lista de Categoria para encontrar la categoria con el id que viene en el link
                {
                    if (item.Id.ToString() == Request.QueryString["id"].ToString())
                    {
                        txtNombre.Text = item.Nombre;
                        txtApellido.Text = item.Apellido;
                        txtDni.Text = item.Dni.ToString();
                        txtCuit.Text = item.Cuit.ToString();
                        txtDomicilio.Text = item.Domicilio;
                        txtMail.Text = item.Mail;
                        txtTelefono.Text = item.Telefono;
                        txtNumCliente.Text = item.NumCliente.ToString();
                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            if (Request.QueryString["id"] != null)
            {
                cliente.Id = int.Parse(Request.QueryString["id"]);
            }

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Dni = Int64.Parse(txtDni.Text);
            cliente.Cuit = Int64.Parse(txtCuit.Text);
            cliente.Domicilio = txtDomicilio.Text;
            cliente.Mail = txtMail.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.NumCliente = int.Parse(txtNumCliente.Text);
            //cliente.FechaAlta = DateTime.UtcNow;

            if (Request.QueryString["id"] != null) //Modificar
            {
                try
                {
                    clienteNegocio.modificar(cliente);
                    //Añadir cartel aclarando si se pudo o no modificar registro
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
                    clienteNegocio.agregar(cliente);
                    //Añadir cartel aclarando si se pudo o no agregar registro
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
            Response.Redirect("Clientes.aspx", false);
        }
    }
}