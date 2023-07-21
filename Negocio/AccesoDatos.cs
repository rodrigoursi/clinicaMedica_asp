using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        int filasAfectadas = 0;
        SqlTransaction transaccion;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=TURNOS_MEDICOS; integrated security=true");
            //conexion = new SqlConnection("server=.\\UTNLABORATORIO; database=CLINICA; User Id=sa; Password=imprimir");
            //conexion = new SqlConnection("server=.; database=CLINICA; integrated security=true");
            //conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CLINICA; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public int ejecutarUpdate(int filas = 1)
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                comando.Transaction = transaccion;
                filasAfectadas = comando.ExecuteNonQuery();
                Thread.Sleep(20);
                if (filasAfectadas == filas) 
                {
                    transaccion.Commit();
                } 
                else transaccion.Rollback();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                transaccion.Dispose();
                transaccion = null;
                conexion.Close();
            }
            return filasAfectadas;
        }

        public int ejecutarDelete(bool fisico =false)
        {
            int filas = fisico ? 2 : 3;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                comando.Transaction = transaccion;
                filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas == filas)
                {
                    transaccion.Commit();
                }
                else transaccion.Rollback();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                transaccion.Dispose();
                transaccion = null;
                conexion.Close();
            }
            return filasAfectadas;
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

    }
}
