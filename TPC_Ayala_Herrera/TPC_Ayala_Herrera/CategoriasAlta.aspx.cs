﻿using System;
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
            }

            else // Agregar
            {
                try
                {
                    categoriaNegocio.agregar(categoria.Descripcion);
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
            Response.Redirect("Categorias.aspx", false);
        }
    }
}