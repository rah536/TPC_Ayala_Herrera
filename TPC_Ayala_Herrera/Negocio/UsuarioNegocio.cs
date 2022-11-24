using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;
using Negocio;
namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();	
			
			try
			{

				datos.setearConsulta("select id, tipoUsuario from usuarios where usuario = @user and  pass = @pass");
				datos.setearParametro("@user", usuario.User);
				datos.setearParametro("@pass", usuario.Pass);

				datos.ejecutarAccion();
				while (datos.Lector.Read())
				{

					usuario.Id = (int)datos.Lector["Id"];
					usuario.tipoUsuario = (int)(datos.Lector["tipoUsuario"]) == 1 ? Usuario.TipoUsuario.ADMIN : Usuario.TipoUsuario.NOMAL;
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


    }
}
