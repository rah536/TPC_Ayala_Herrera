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
				datos.setearConsulta("select idproveedor, razonSocial,Nombre,Apellido, dni, cuit, domicilio, mail, telefono,estado,idRol from proveedor");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Proveedor aux = new Proveedor();
					aux.IdProveedor = (int)datos.Lector["IdProveedor"];
					aux.RazonSocial = (string)datos.Lector["razonSocial"];
					//	aux.IdProducto = (int)datos.Lector["idProducto"];
					aux.Nombre = (string)datos.Lector["nombre"];
					aux.Apellido = (string)datos.Lector["apellido"];
					aux.Dni = (Int64)datos.Lector["dni"];
					aux.Cuit = (Int64)datos.Lector["cuit"];
					aux.Domicilio = (string)datos.Lector["domicilio"];
					aux.Mail = (string)datos.Lector["mail"];
					aux.Telefono = (string)datos.Lector["telefono"];
					aux.Estado = (bool)datos.Lector["estado"];
					aux.IdRol = (int)datos.Lector["idRol"];

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
                datos.setearConsulta("insert into Proveedor (razonSocial,Nombre,Apellido, dni, cuit, domicilio, mail, telefono,estado,idRol)" +
                    " VALUES ('" + proveedor.RazonSocial + "' ,'"+proveedor.Nombre+"', '"+proveedor.Apellido+"', "+proveedor.Cuit+", '"+proveedor.Domicilio+"', '"+proveedor.Mail+"',"+proveedor.Telefono+", "+proveedor.Estado+","+proveedor.IdRol+")");
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
