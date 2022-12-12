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
                //datos.setearConsulta("Select Id, Codigo, IdProveedor, Descripcion, Marca, Categoria, Costo, StockActual, StockMinimo, PorcentajeGanancia, UrlImagen from Productos");
                datos.setearConsulta("Select Prod.Id, Prod.Codigo, prov.IdProveedor as IdProveedor, prov.razonSocial as razonSocial, Prod.Descripcion, Mar.Descripcion as Marca, Cat.Descripcion as Categoria, Prod.CostoUnidad, Prod.StockActual, Prod.StockMinimo, Prod.PorcentajeGanancia, Prod.UrlImagen from Productos Prod Inner Join proveedor prov On Prod.IdProveedor = prov.idProveedor Inner Join Marca Mar On Mar.Id = Prod.IdMarca Inner Join Categoria Cat On Cat.Id = Prod.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (int)datos.Lector["Codigo"];
                    aux.Proveedor = new Proveedor();
                    aux.Proveedor.Id = (int)datos.Lector["IdProveedor"];
                    aux.Proveedor.RazonSocial = (string)datos.Lector["razonSocial"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.CostoUnidad = (float)Convert.ToDecimal(datos.Lector["CostoUnidad"]);
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
        public void agregar(Producto producto, int cantidadIngreso)
        {
            AccesoDatos datos = new AccesoDatos();

            //usar los decimales con PUNTO
            //al usar COMA se pincha

            producto.StockActual = cantidadIngreso;
            try
            {
                //datos.setearConsulta("insert into Productos (Codigo, IdProveedor, Descripcion, IdMarca, IdCategoria, CostoUnidad, StockActual, StockMinimo, PorcentajeGanancia, UrlImagen, Estado) VALUES ("+producto.Codigo+", "+producto.Proveedor.Id+", '"+producto.Descripcion+"', "+producto.Marca.Id+", "+producto.Categoria.Id+", "+producto.CostoUnidad+", "+producto.StockActual+", "+producto.StockMinimo+", 0.25, 'ash.jpg', 1)");
                datos.setearConsulta("insert into Productos (Codigo, IdProveedor, Descripcion, IdMarca, IdCategoria, CostoUnidad, StockActual, StockMinimo, PorcentajeGanancia, UrlImagen, Estado) VALUES (" + producto.Codigo + ", " + producto.Proveedor.Id + ", '" + producto.Descripcion + "', " + producto.Marca.Id + ", " + producto.Categoria.Id + ", " + producto.CostoUnidad + ", " + producto.StockActual + ", " + producto.StockMinimo + ", " + producto.PorcentajeGanancia + ", '" + producto.UrlImagen + "', 1)");
                datos.ejecutarAccion();
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
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Productos where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Productos set Codigo = " + producto.Codigo + ", IdProveedor = " + producto.Proveedor.Id + ", Descripcion = '" + producto.Descripcion + "', IdMarca = " + producto.Marca.Id + ", IdCategoria = " + producto.Categoria.Id + ", StockMinimo = " + producto.StockMinimo + ", PorcentajeGanancia = " + producto.PorcentajeGanancia + ", UrlImagen = '" + producto.UrlImagen + "' where Id = " + producto.Id + "");
                datos.ejecutarAccion();
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

        public void actualizarStock(List<CompraOperacionDetalle> opDetalle)
        {
            AccesoDatos datos = new AccesoDatos();

            foreach (CompraOperacionDetalle item in opDetalle)
            {

                try
                {
                    //datos.setearConsulta("Update Productos set CostoUnidad = " + item.Producto.CostoUnidad + ", StockActual = " + item.Producto.StockActual + " where Id = " + item.Producto.Id + "");
                    datos.setearConsulta("Update Productos set CostoUnidad = " + item.Producto.CostoUnidad + ", StockActual = (Select StockActual +" + item.Producto.StockActual + ") where Id = " + item.Producto.Id + "");
                    datos.ejecutarAccion();
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

        public void actualizarStock(List<VentaOperacionDetalle> opDetalle)
        {
            AccesoDatos datos = new AccesoDatos();

            foreach (VentaOperacionDetalle item in opDetalle)
            {

                try
                {
                    //datos.setearConsulta("Update Productos set CostoUnidad = " + item.Producto.CostoUnidad + ", StockActual = " + item.Producto.StockActual + " where Id = " + item.Producto.Id + "");
                    datos.setearConsulta("Update Productos set StockActual = (Select StockActual -" + item.Cantidad + ") where Id = " + item.Producto.Id + "");
                    datos.ejecutarAccion();
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
}
