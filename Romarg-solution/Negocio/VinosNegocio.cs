using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using negocio;


namespace Negocio
{
    public class VinosNegocio
    {

        public List<Vinos> ListarSP()
        {
            List<Vinos> lista = new List<Vinos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vinos aux = new Vinos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.UrlImage = (string)datos.Lector["UrlImg"];
                    aux.Tipo = new Tipo();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Bodega = new Bodega();
                    aux.Bodega.Id = (int)datos.Lector["IdBodega"];
                    aux.Bodega.Nombre = (string)datos.Lector["Nombre"];

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
        
        public void AgregarVinoSP(Vinos vino)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedAgregarVino");
                datos.setearParametro("@IdTipo", vino.Tipo.Id);
                datos.setearParametro("@IdBodega", vino.Bodega.Id);
                datos.setearParametro("@Descripcion", vino.Descripcion);
                datos.setearParametro("@Nombre", vino.Nombre);
                datos.setearParametro("@Año", vino.Anio);
                datos.setearParametro("@Img", vino.UrlImage);
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

        public void ModificarSP()
        {
        }
    }
}
