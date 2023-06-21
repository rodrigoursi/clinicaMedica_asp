using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    internal class HorarioNegocio
    {
        public List<Horarios> listar()
        {
            List<Horarios> lista = new List<Horarios>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, hora_inicio, hora_fin, turno_asociado FROM horarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horarios horario = new Horarios();
                    horario.id = (int)datos.Lector["id"];
                    horario.horaInicio = (DateTime)datos.Lector["hora_inicio"];
                    horario.horaInicio = (DateTime)datos.Lector["hora_fin"];
                    horario.turnoAsociado = (Turno)datos.Lector["turno_asociado"];


                    lista.Add(horario);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de HORARIOS");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Horarios horario)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE horarios SET hora_inicio=@inicio, hora_fin=@fin, turno_asociado=@turno WHERE id=@id");
                datos.setearParametro("@id", horario.id);
                datos.setearParametro("@inicio", horario.horaInicio);
                datos.setearParametro("@fin", horario.horaFin);
                datos.setearParametro("@turno", horario.turnoAsociado);
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

        public int agregar(Horarios horario)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO horarios (hora_inicio, hora_fin, turno_asociado) VALUES (@inicio, @fin, @turno)");
                datos.setearParametro("@inicio", horario.horaInicio);
                datos.setearParametro("@fin", horario.horaFin);
                datos.setearParametro("@turno", horario.turnoAsociado);
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
                datos.setearConsulta("DELETE FORM horarios WHERE id= @id");
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
