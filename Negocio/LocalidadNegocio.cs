using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class LocalidadNegocio
    {
        public List<Localidad> listar()
        {
            List<Localidad> lista = new List<Localidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, localidad FROM localidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Localidad localidad = new Localidad();
                    localidad.id = (short)datos.Lector["id"];
                    localidad.localidad = (string)datos.Lector["localidad"];


                    lista.Add(localidad);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de LOCALIDADES");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Localidad localidad)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE localidades SET localidad=@localidad, id_prov=@provncia WHERE id=@id");
                datos.setearParametro("@id", localidad.id);
                datos.setearParametro("@localidad", localidad.localidad);
                datos.setearParametro("@provincia", localidad.provincia.id);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return resultado;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }

        public int agregar(Localidad localidad)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO localidades (localidad, id_prov) VALUES (@localidad, @provincia)");
                datos.setearParametro("@localidad", localidad.localidad);
                datos.setearParametro("@provincia", localidad.provincia.id);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
                return resultado;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }

        public int eliminar(int id)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FORM localidades WHERE id= @id");
                datos.setearParametro("@id", id);
                resultado = datos.ejecutarUpdate();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return resultado;
        }
    }
}
