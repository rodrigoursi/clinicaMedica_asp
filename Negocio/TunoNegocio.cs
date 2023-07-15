using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class TunoNegocio
    {
        public List<Turno> listar(string filtros = "")
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, id_paciente, id_medico, fecha_hora, observaciones, estado, altaUsu, modiUsu, bajaUsu, altaFecha, modiFecha, bajaFecha FROM turnos" + filtros);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno();
                    turno.id = (int)datos.Lector["id"];
                    turno.paciente.id = (int)datos.Lector["id_paciente"];
                    turno.medico.id = (int)datos.Lector["id_medico"];
                    turno.fechaYHora = (DateTime)datos.Lector["fecha_hora"];
                    turno.observaciones = (string)datos.Lector["observaciones"];
                    turno.estado.id = (byte)datos.Lector["estado"];
                    turno.altaUsuario.codigoUsuario = (string)datos.Lector["altaUsu"];
                    turno.modificacionUsuario.codigoUsuario = datos.Lector["modiUsu"].ToString();
                    turno.bajaUsuario.codigoUsuario = datos.Lector["bajaUsu"].ToString();
                    turno.altaFecha = (DateTime)datos.Lector["altaFecha"];
                    turno.modificacionFecha = datos.Lector["modiFecha"] != DBNull.Value ? (DateTime)datos.Lector["modiFecha"] : DateTime.MinValue;
                    turno.bajaFecha = datos.Lector["bajaFecha"] != DBNull.Value ? (DateTime)datos.Lector["bajaFecha"] : DateTime.MinValue;


                    lista.Add(turno);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de TURNOS");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Turno turno)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE " +
                                        "turnos" +
                                    " SET " +
                                        "id_paciente=@paciente," +
                                        "id_medico=@medico," +
                                        "fecha_hora=@fechaHora," +
                                        "observaciones=@observaciones," +
                                        "estado=@estado," +
                                        "modiUsu=@modiUsuario," +
                                        "modiFecha=@modiFecha " +
                                        "WHERE" +
                                            "id=@id");

                datos.setearParametro("@id", turno.id);
                datos.setearParametro("@paciente", turno.paciente.id);
                datos.setearParametro("@medico", turno.medico.id);
                datos.setearParametro("@fechaHora", turno.fechaYHora);
                datos.setearParametro("@observaciones", turno.observaciones);
                datos.setearParametro("@estado", turno.estado.id);
                datos.setearParametro("@modiUsuario", turno.modificacionUsuario.id);
                datos.setearParametro("@modiFecha", turno.modificacionFecha);
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

        public int agregar(Turno turno)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO " +
                                        "turnos (id_paciente," +
                                        "id_medico," +
                                        "fecha_hora," +
                                        "observaciones," +
                                        "estado," +
                                        "altaUsu) " +
                                    "VALUES " +
                                        "(@paciente," +
                                        "@medico," +
                                        "@fechaHora," +
                                        "@observaciones," +
                                        "@estado, " +
                                        "@altaUsu)");

                datos.setearParametro("@paciente", turno.paciente.id);
                datos.setearParametro("@medico", turno.medico.id);
                datos.setearParametro("@fechaHora", turno.fechaYHora);
                datos.setearParametro("@observaciones", turno.observaciones);
                datos.setearParametro("@estado", turno.estado.id);
                datos.setearParametro("@altaUsu", "1234"); //aca hay q hacer q llegue el usuario q esta operando
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
                datos.setearConsulta("DELETE FROM turnos WHERE id= @id");
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
