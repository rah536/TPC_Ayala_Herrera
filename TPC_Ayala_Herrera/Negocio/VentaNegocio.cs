using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        public bool agregar(VentaOperacion ventaOp)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into VentaOperacion (IdCliente, FechaVenta, Total) Values (" + ventaOp.Cliente.Id + ", GETDATE(), " + ventaOp.Total + ")");
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

        public int rescatarIdOperacion()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select top 1 Id from VentaOperacion order by Id desc");
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

        public void agregarDetalle(List<VentaOperacionDetalle> opDetalles, int IdOp)
        {
            AccesoDatos datos = new AccesoDatos();
            foreach (VentaOperacionDetalle item in opDetalles)
            {
                try
                {
                    datos.setearConsulta("insert into VentaOperacionDetalle (IdVentaOperacion, IdProducto, Cantidad, SubTotal) values (" + IdOp + ", " + item.Producto.Id + ", " + item.Cantidad + ", " + item.SubTotal + ")");
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

        public List<VentaOperacion> listarHistorial()
        {
            List<VentaOperacion> lista = new List<VentaOperacion>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, IdCliente, FechaVenta, Total from VentaOperacion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentaOperacion aux = new VentaOperacion();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    //recorro lista cliente y busco match con id,para
                    //sumar datos del cliente
                    ClienteNegocio cNegocio = new ClienteNegocio();
                    List<Cliente> listaCliente = cNegocio.listar();

                    foreach (Cliente item in listaCliente)
                    {
                        if (aux.Cliente.Id == item.Id)
                        {
                            aux.Cliente.NumCliente = item.NumCliente;
                            aux.Cliente.Nombre = item.Nombre;
                            aux.Cliente.Apellido = item.Apellido;
                            aux.Cliente.Mail = item.Mail;
                        }
                    }

                    aux.FechaVenta = (DateTime)datos.Lector["FechaVenta"];
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

        public List<VentaOperacionDetalle> listarDetalle(string id)
        {
            List<VentaOperacionDetalle> lista = new List<VentaOperacionDetalle>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IdVentaOperacion, IdProducto, Cantidad, SubTotal from VentaOperacionDetalle where IdVentaOperacion = " + id + "");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentaOperacionDetalle aux = new VentaOperacionDetalle();

                    aux.IdVenta = (int)datos.Lector["IdVentaOperacion"];
                    aux.Producto = new Producto();
                    aux.Producto.Id = (int)datos.Lector["IdProducto"];
                    //recorro lista productos y busco match con id, para
                    //sumar el resto de datos del producto
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
