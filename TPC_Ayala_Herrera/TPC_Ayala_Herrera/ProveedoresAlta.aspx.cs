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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["id"] != null && !IsPostBack) //Si el link viene con un id, cargo los datos en los textbox
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                List<Proveedor> proveedor = proveedorNegocio.listar();

                foreach (Proveedor item in proveedor) //recorro la lista de proveedores para encontrar el proveedor con el id que viene en el link
                {
                    if (item.IdProveedor.ToString() == Request.QueryString["id"].ToString())
                    {
                        tbRazonSocial.Text = item.RazonSocial;

                        tbNombre.Text = item.Nombre;
                        tbApellido.Text = item.Apellido;
                        tbDni.Text = item.Dni.ToString();
                        tbCuit.Text = item.Cuit.ToString();
                        tbDomicilio.Text = item.Domicilio;
                        tbMail.Text = item.Mail;
                        tbTelefono.Text = item.Telefono;


                    }
                }
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Proveedor aux = new Proveedor();

            aux.RazonSocial = tbRazonSocial.Text;
            aux.Nombre = tbNombre.Text;
            aux.Apellido = tbApellido.Text;
            aux.Dni = Convert.ToInt64(tbDni.Text);
            aux.Cuit = Convert.ToInt64(tbCuit.Text);
            aux.Domicilio = tbDomicilio.Text;
            aux.Mail = tbMail.Text;
            
            aux.Telefono = tbTelefono.Text;
            aux.Estado = Convert.ToBoolean(Convert.ToInt16(1));
            aux.IdRol = Convert.ToInt16(3);

            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            if (Request.QueryString["id"] != null) // modificar
            {
                try
                {
                    aux.IdProveedor = int.Parse(Request.QueryString["id"]);
                    proveedorNegocio.modificar(aux);
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
                    proveedorNegocio.agregar(aux);
                    PanelAgregadoOk.Visible = true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            /*ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();
            if (Request.QueryString["id"] != null)
            {
                proveedor.IdProveedor = int.Parse(Request.QueryString["id"]);
            }






            if (Request.QueryString["id"] != null) //Modificar
            {
                try
                {
                    proveedorNegocio.modificar(proveedor);
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
                    proveedorNegocio.agregar(proveedor);
                    //Añadir cartel aclarando si se pudo o no agregar registro
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Agregar cartel de error
                }
            }*/
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx", false);
        }

        protected void btnCerrarPanelModificadoOk_Click(object sender, EventArgs e)
        {
            PanelModificadoOk.Visible = false;
            Response.Redirect("Proveedores.aspx", false);
        }

        protected void btnCerrarPanelAgregadoOk_Click(object sender, EventArgs e)
        {
            PanelAgregadoOk.Visible = false;
            Response.Redirect("Proveedores.aspx", false);
        }
    }
}