using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using negocio;


namespace Negocio
{
    public class VinosNegocio
    {

        public List<Vinos> ListarSP(string id = "")
        {
            List<Vinos> lista = new List<Vinos>();
            AccesoDatos datos = new AccesoDatos();
            SqlCommand comando = new SqlCommand();
            try
            {
                datos.setearConsulta("select V.Id, V.Nombre, V.Anio, V.Descripcion, V.Activo, V.UrlImg, V.IdTipo, V.IdBodega, B.Nombre Bodega, T.Descripcion Tipo from Vinos V, Bodega B, Tipo T Where V.IdBodega = B.Id and V.IdTipo = T.Id ");
                if (id != "")
                    datos.setearConsulta("select V.Id, V.Nombre, V.Anio, V.Descripcion, V.Activo, V.UrlImg, V.IdTipo, V.IdBodega, B.Nombre Bodega, T.Descripcion Tipo from Vinos V, Bodega B, Tipo T Where V.IdBodega = B.Id and V.IdTipo = T.Id and V.Id = " + id);
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

        public void Modificar(Vinos vino)
        {
            AccesoDatos datos =new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Vinos set Nombre = @nombre, anio = @año, Descripcion = @desc, UrlImg = @img, IdTipo = @IdTipo, IdBodega = @IdBodega where id = @id ");
                datos.setearParametro("@nombre", vino.Nombre);
                datos.setearParametro("@año",DateTime.Parse(vino.Anio.ToString("yyyy-MM-dd")));
                datos.setearParametro("@desc", vino.Descripcion);
                datos.setearParametro("@img", vino.UrlImage);
                datos.setearParametro("@IdTipo", vino.Tipo.Id);
                datos.setearParametro("@IdBodega", vino.Bodega.Id);
                datos.setearParametro("@Id", vino.Id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
