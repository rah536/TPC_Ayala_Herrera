using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
				datos.setearConsulta("select id, razonSocial,idProducto from proveedor");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Proveedor aux = new Proveedor();
					aux.Id = (int)datos.Lector["Id"];
					aux.RazonSocial = (string)datos.Lector["razonSocial"];
					if(datos.Lector["idProducto"] != null)
					{
						aux.IdProducto = (int)datos.Lector["idProducto"];


                    }
					else
					{
						aux.IdProducto = 0;

					}
					

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
