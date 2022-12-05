using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;
using Negocio;
namespace Negocio
{
    public class UsuarioNegocio

    {

		public int insertarNuevo(Usuario nuevo) {

			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearProcedimiento("insertarNuevo");
				datos.setearParametro("@email", nuevo.Email);
				datos.setearParametro("@nombre", nuevo.Nombre);
				datos.setearParametro("@apellido", nuevo.Apellido);
				datos.setearParametro("@pass", nuevo.Password);
				datos.setearParametro("@admin", nuevo.Admin);

				return datos.ejecutarAccionScalar();
		
			}
			catch (Exception ex)
			{
				throw ex;

				//Session["error", ex.ToString()];
			}


			finally
			{
				datos.cerrarConexion();			}
		
		
		
		}



		public bool Login (Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Select Id, email, pass , admin from usuarios where email = @email and pass = @pass");
				datos.setearParametro("@email", usuario.Email);
				datos.setearParametro("@pass", usuario.Password);
				

                datos.ejecutarLectura();

				if (datos.Lector.Read())
				{

					usuario.Admin = (bool)datos.Lector["admin"];
				    usuario.Id = (int)datos.Lector["id"];
					return true;
				}
				return false;


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



        /*
        public bool Loguear(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();	
			
			try
			{

				datos.setearConsulta("select id, Administrador from usuarios where usuario = @user and  pass = @pass");
				datos.setearParametro("@user", usuario.User);
				datos.setearParametro("@pass", usuario.Pass);

				//datos.ejecutarAccion();
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{

					usuario.Id = (int)datos.Lector["Id"];
					usuario.TipoUsuario = (int)(datos.Lector["Administrador"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
					return true;


				}
				return false;

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

		*/
    }
}
