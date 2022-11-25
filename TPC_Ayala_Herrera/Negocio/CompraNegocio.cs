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
    }
}
