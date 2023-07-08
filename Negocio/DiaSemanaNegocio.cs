using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class DiaSemanaNegocio
    {
        public List<DiaSemana> listar()
        {
            List<DiaSemana> lista = new List<DiaSemana>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, cod_dia, diaSemana" +
                                    " FROM dSemana");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DiaSemana dSemana = new DiaSemana();
                    dSemana.id = (byte)datos.Lector["id"];
                    dSemana.codDia = (byte)datos.Lector["cod_dia"];
                    dSemana.diaSemana = (string)datos.Lector["diaSemana"];


                    lista.Add(dSemana);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de DIAS DE LA SEMANA");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(DiaSemana dSemana)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE dSemana SET cod_dia=@codDia, diaSemana=@diaSemana WHERE id=@id");
                datos.setearParametro("@id", dSemana.id);
                datos.setearParametro("@codDia", dSemana.codDia);
                datos.setearParametro("@diaSemana", dSemana.diaSemana);
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

        public int agregar(DiaSemana dSemana)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO dSemana (cod_dia, diaSemana) VALUES (@codDia, @diaSemana)");
                datos.setearParametro("@codDia", dSemana.codDia);
                datos.setearParametro("@diaSemana", dSemana.diaSemana);
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
                datos.setearConsulta("DELETE FROM dSemana WHERE id= @id");
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
