using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> listar()
        {
            List<Estado> lista = new List<Estado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, codigo, estado, defecto FROM estados");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estado estado = new Estado();
                    estado.id = (byte)datos.Lector["id"];
                    estado.codigo = (string)datos.Lector["codigo"];
                    estado.estado = (string)datos.Lector["estado"];
                    estado.defecto = (bool)datos.Lector["defecto"];


                    lista.Add(estado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de ESTADOS");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Estado estado)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE estados SET codigo=@codigo, estado=@nombre WHERE id=@id");
                datos.setearParametro("@id", estado.id);
                datos.setearParametro("@codigo", estado.codigo);
                datos.setearParametro("@nombre", estado.estado);
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

        public int agregar(Estado estado)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO estados (codigo, estado) VALUES (@codigo, @nombre)");
                datos.setearParametro("@codigo", estado.codigo);
                datos.setearParametro("@nombre", estado.estado);
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
                datos.setearConsulta("DELETE FROM estados WHERE id= @id");
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
