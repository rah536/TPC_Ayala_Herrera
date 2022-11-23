using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
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
                datos.setearConsulta("select idproveedor, razonSocial,Nombre,Apellido, dni, cuit, domicilio, mail, telefono,estado,idRol, fechaAlta from proveedor");
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
                    var x = datos.Lector["fechaAlta"];
                   
                    //aux.FechaAlta =(DateTime)x;

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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Proveedor where idProveedor = @idProveedor");
                datos.setearParametro("@idProveedor", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("update proveedor set razonSocial = @razonSocial, Nombre = @nombre,Apellido = @Apellido, DNI = @dni, cuit = @cuit, domicilio = @domicilio, mail = @mail, telefono= @telefono where IdProveedor = @idProveedor");
                datos.setearParametro("@razonSocial", proveedor.RazonSocial);
                datos.setearParametro("@nombre", proveedor.Nombre);
                datos.setearParametro("@Apellido", proveedor.Apellido);
                datos.setearParametro("@dni", proveedor.Dni);
                datos.setearParametro("@cuit", proveedor.Cuit);
                // datos.setearParametro("@idCategoria", proveedor.categoria);
                datos.setearParametro("@domicilio", proveedor.Domicilio);
                datos.setearParametro("@mail", proveedor.Mail);
                datos.setearParametro("@telefono", proveedor.Telefono);
                datos.setearParametro("@idProveedor", proveedor.IdProveedor);
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

        public void agregar(Proveedor proveedor)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SET DATEFORMAT dmy insert into Proveedor (razonSocial,Nombre,Apellido, dni, cuit, domicilio, mail, telefono,estado,idRol, fechaAlta) VALUES ('" + proveedor.RazonSocial + "','" + proveedor.Nombre + "','" + proveedor.Apellido + "','" + proveedor.Dni + "','" + proveedor.Cuit + "','" + proveedor.Domicilio + "','" + proveedor.Mail + "','" + proveedor.Telefono + "','" + proveedor.Estado + "','" + proveedor.IdRol + "','" + proveedor.FechaAlta + "')");
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
