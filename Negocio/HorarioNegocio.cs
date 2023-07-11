using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class HorarioNegocio
    {
        public List<Horarios> listar(string filtro = "")
        {
            List<Horarios> lista = new List<Horarios>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT horarios.id, id_medico, id_dia, hora_ini, hora_fin FROM horarios " + filtro);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horarios horario = new Horarios();
                    horario.id = (int)datos.Lector["id"];
                    horario.idMedico.id = (int)datos.Lector["id_medico"];
                    horario.idDia.id = (byte)datos.Lector["id_dia"];
                    string hora = datos.Lector["hora_ini"].ToString();
                    horario.horaInicio = DateTime.Parse(hora);
                    hora = datos.Lector["hora_fin"].ToString();
                    horario.horaFin = DateTime.Parse(hora);
                    //horario.turnoAsociado.id = (int)datos.Lector["turno_asociado"];


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
                datos.setearConsulta("UPDATE horarios SET  @medico=id_medico, @dia=id_dia, hora_ini=@inicio, hora_fin=@fin WHERE id=@id");
                datos.setearParametro("@id", horario.id);
                datos.setearParametro("@medico", horario.idMedico.id);
                datos.setearParametro("@dia", horario.idDia.id);
                datos.setearParametro("@inicio", horario.horaInicio);
                datos.setearParametro("@fin", horario.horaFin);
                //datos.setearParametro("@turno", horario.turnoAsociado);
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
                datos.setearConsulta("INSERT INTO horarios (id_medico, id_dia, hora_ini, hora_fin) VALUES (@medico, @dia, @inicio, @fin)");
                datos.setearParametro("@medico", horario.idMedico.id);
                datos.setearParametro("@dia", horario.idDia.id);
                datos.setearParametro("@inicio", horario.horaInicio);
                datos.setearParametro("@fin", horario.horaFin);
                //datos.setearParametro("@turno", horario.turnoAsociado);
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
                datos.setearConsulta("DELETE FROM horarios WHERE id= @id");
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
