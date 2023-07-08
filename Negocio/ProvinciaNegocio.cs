using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> listar()
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, provincia FROM provincias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia provincia = new Provincia();
                    provincia.id = (byte)datos.Lector["id"];
                    provincia.provincia = (string)datos.Lector["provincia"];


                    lista.Add(provincia);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de PROVINCIAS");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Provincia provincia)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE provincias SET provincia=@provincia WHERE id=@id");
                datos.setearParametro("@id", provincia.id);
                datos.setearParametro("@provincia", provincia.provincia);
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

        public int agregar(Provincia provincia)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO provincias (provincia) VALUES (@provincia)");
                datos.setearParametro("@provincia", provincia.provincia);
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
                datos.setearConsulta("DELETE FROM provincias WHERE id= @id");
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
