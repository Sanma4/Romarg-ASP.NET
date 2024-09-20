using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BodegaNegocio
    {
        public List<Bodega> listarSP()
        {
            List<Bodega> lista = new List<Bodega>();
            AccesoDatos datos = new AccesoDatos();  
            try
            {
                datos.setearProcedimiento("storedListarBodega");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Bodega aux = new Bodega();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Id = (int)datos.Lector["Id"];
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

        public void AgregarBodega(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Bodega values (@nombre)");
                datos.setearParametro("@nombre", nombre);
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

        public void EliminarBodega(int seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from Bodega where Id = @Id");
                datos.setearParametro("@Id", seleccionado);
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
