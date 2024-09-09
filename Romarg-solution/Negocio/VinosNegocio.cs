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
        public List<Vinos> Listar()
        {
            List<Vinos> lista = new List<Vinos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select V.Id, V.Nombre, V.Anio, V.Descripcion, V.Activo, V.UrlImg, B.Nombre Bodega, T.Descripcion Tipo from Vinos V, Bodega B, Tipo T Where V.IdBodega = B.Id and V.IdTipo = T.Id");
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
        }

    }
}
