using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CompraNegocio
    {
        public bool agregar(CompraOperacion compraOp)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into CompraOperacion (IdProveedor, FechaCompra, Total) Values (" + compraOp.Proveedor.Id + ", GETDATE(), " + compraOp.Total + ")");
                //ciclo y guardar list<opDetalle>.count
                //opdetalle sacar foreign key

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarDetalle(List<CompraOperacionDetalle> opDetalles, int IdOp)
        {
            AccesoDatos datos = new AccesoDatos();
            foreach (CompraOperacionDetalle item in opDetalles)
            {
                try
                {
                    datos.setearConsulta("insert into CompraOperacionDetalle (IdCompraOperacion, IdProducto, Cantidad, SubTotal) values (" + IdOp + ", " + item.Producto.Id + ", " + item.Cantidad + ", " + item.SubTotal + ")");
                    //ciclo y guardar list<opDetalle>.count
                    //opdetalle sacar foreign key
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

        public int rescatarIdOperacion()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select top 1 Id from CompraOperacion order by Id desc");
                datos.ejecutarLectura();
                int Id = 0;
                while (datos.Lector.Read())
                {
                    Id = (int)datos.Lector["Id"];
                }

                return Id;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<CompraOperacion> listarHistorial()
        {
            List<CompraOperacion> lista = new List<CompraOperacion>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, IdProveedor, FechaCompra, Total from CompraOperacion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CompraOperacion aux = new CompraOperacion();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Proveedor = new Proveedor();
                    aux.Proveedor.Id = (int)datos.Lector["IdProveedor"];
                    //recorro listado de proveedor y busco match con id para
                    //sumar razon social
                    ProveedorNegocio pNegocio = new ProveedorNegocio();
                    List<Proveedor> listaProveedor = pNegocio.listar();

                    foreach (Proveedor item in listaProveedor)
                    {
                        if (aux.Proveedor.Id == item.IdProveedor)
                        {
                            aux.Proveedor.RazonSocial = item.RazonSocial;
                        }
                    }

                    aux.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    aux.Total = (float)Convert.ToDecimal(datos.Lector["Total"]);

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

        public List<CompraOperacionDetalle> listarDetalle(string id)
        {
            List<CompraOperacionDetalle> lista = new List<CompraOperacionDetalle>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IdCompraOperacion, IdProducto, Cantidad, SubTotal from CompraOperacionDetalle where IdCompraOperacion = " + id + "");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CompraOperacionDetalle aux = new CompraOperacionDetalle();

                    aux.IdCompra = (int)datos.Lector["IdCompraOperacion"];
                    aux.Producto = new Producto();
                    aux.Producto.Id = (int)datos.Lector["IdProducto"];
                    //recorro listado de productos y busco match con id para
                    //sumar el resto de datos
                    ProductoNegocio pNegocio = new ProductoNegocio();
                    List<Producto> listaProducto = pNegocio.listar();

                    foreach (Producto item in listaProducto)
                    {
                        if (aux.Producto.Id == item.Id)
                        {
                            aux.Producto.Descripcion = item.Descripcion;
                            aux.Producto.Codigo = item.Codigo;
                        }
                    }

                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.SubTotal = (float)Convert.ToDecimal(datos.Lector["SubTotal"]);

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
