using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
		public List<Cliente> listar()
		{

			List<Cliente> lista = new List<Cliente>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Select Id, Nombre, Apellido, Dni, Cuit, Domicilio, Mail, Telefono, Estado, IdRol, FechaAlta, NumeroCliente from Cliente");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Cliente aux = new Cliente();
					aux.Id = (int)datos.Lector["Id"];
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Apellido = (string)datos.Lector["Apellido"];
					aux.Dni = (int)datos.Lector["Dni"];
					aux.Cuit = (int)datos.Lector["Cuit"];
					aux.Domicilio = (string)datos.Lector["Domicilio"];
					aux.Mail = (string)datos.Lector["Mail"];
					aux.Telefono = (string)datos.Lector["Telefono"];
					aux.Estado = (bool)datos.Lector["Estado"];
					aux.IdRol = (int)datos.Lector["IdRol"];
					//se comenta fecha porque al traer dato null se rompe
					//aux.FechaAlta = (DateTime)datos.Lector["FechaAlta"];
					aux.NumCliente = (int)datos.Lector["NumeroCliente"];

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

		public void agregar(Cliente cliente)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				//se comenta consulta con FechaAlta porque pincha- Reparar-
				//datos.setearConsulta("insert into Cliente (Nombre, Apellido, Dni, Cuit, Domicilio, Mail, Telefono, Estado, IdRol, FechaAlta, NumeroCliente) VALUES ('"+cliente.Nombre+"','"+cliente.Apellido+"', "+cliente.Dni+", "+cliente.Cuit+",'"+cliente.Domicilio+"', '"+cliente.Mail+"', '"+cliente.Telefono+"',"+1+","+2+","+cliente.FechaAlta+","+cliente.NumCliente+")");
				datos.setearConsulta("insert into Cliente (Nombre, Apellido, Dni, Cuit, Domicilio, Mail, Telefono, Estado, IdRol, NumeroCliente) VALUES ('" + cliente.Nombre + "','" + cliente.Apellido + "', " + cliente.Dni + ", " + cliente.Cuit + ",'" + cliente.Domicilio + "', '" + cliente.Mail + "', '" + cliente.Telefono + "'," + 1 + "," + 2 + "," + cliente.NumCliente + ")");
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
				datos.setearConsulta("delete from Cliente where id = @id");
				datos.setearParametro("@id", id);
				datos.ejecutarAccion();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void modificar(Cliente cliente)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				//datos.setearConsulta("update Cliente set Nombre = '"+cliente.Nombre+"', Apellido = '"+cliente.Apellido+"', Dni = "+cliente.Dni+", Cuit = "+cliente.Cuit+", Domicilio = '"+cliente.Domicilio+"', Mail = '"+cliente.Mail+"', Telefono = '"+cliente.Telefono+"', FechaAlta = "+cliente.FechaAlta+", NumeroCliente = "+cliente.NumCliente+" where Id = "+cliente.Id+"");
				datos.setearConsulta("update Cliente set Nombre = '" + cliente.Nombre + "', Apellido = '" + cliente.Apellido + "', Dni = " + cliente.Dni + ", Cuit = " + cliente.Cuit + ", Domicilio = '" + cliente.Domicilio + "', Mail = '" + cliente.Mail + "', Telefono = '" + cliente.Telefono + "', NumeroCliente = " + cliente.NumCliente + " where Id = " + cliente.Id + "");

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
