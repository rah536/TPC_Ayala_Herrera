using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Codigo, IdProveedor, Descripcion, Marca, Categoria, Costo, StockActual, StockMinimo, PorcentajeGanancia, UrlImagen from Productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (int)datos.Lector["Codigo"];
                    aux.IdProveedor = (int)datos.Lector["IdProveedor"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = (string)datos.Lector["Marca"];
                    aux.Categoria = (string)datos.Lector["Categoria"];
                    aux.Costo = (float)Convert.ToDecimal(datos.Lector["Costo"]);
                    aux.StockActual = (int)datos.Lector["StockActual"];
                    aux.StockMinimo = (int)datos.Lector["StockMinimo"];
                    aux.PorcentajeGanancia = (float)Convert.ToDecimal(datos.Lector["PorcentajeGanancia"]);
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    
                    if (datos.Lector["UrlImagen"] == DBNull.Value) { aux.UrlImagen = "."; }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }




        }
    }
}
