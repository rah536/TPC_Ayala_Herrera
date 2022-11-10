using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
	public class ProveedorNegocio
	{
		public List<Proveedor> listar()
		{

			List<Proveedor> lista = new List<Proveedor>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select idProveedor, razonSocial,idProducto from proveedor");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Proveedor aux = new Proveedor();
					aux.IdProveedor = (int)datos.Lector["IdProveedor"];
					aux.RazonSocial = (string)datos.Lector["razonSocial"];
					//	aux.IdProducto = (int)datos.Lector["idProducto"];
					aux.IdProducto = 0;
				
					

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
		
		public void agregar(Proveedor proveedor)
		{

            AccesoDatos datos = new AccesoDatos();
			try
			{
                datos.setearConsulta("insert into Proveedor (razonSocial) VALUES ('" + proveedor.RazonSocial + "')");
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
