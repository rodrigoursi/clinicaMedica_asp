using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class RolNegocio
    {
        public List<Rol> listar()
        {
            List<Rol> lista = new List<Rol>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id, codigo, rol FROM roles");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Rol rol = new Rol();
                    rol.id = (byte)datos.Lector["id"];
                    rol.codigo = (string)datos.Lector["codigo"];
                    rol.rol = (string)datos.Lector["rol"];

                    // Imprimir los valores para verificar
                    Debug.WriteLine($"id: {rol.id}, codigo: {rol.codigo}, nombre: {rol.rol}");

                    lista.Add(rol);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de ROLES");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Rol rol)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE roles SET codigo=@codigo, rol=@rol WHERE id=@id");
                datos.setearParametro("@id", rol.id);
                datos.setearParametro("@codigo", rol.codigo);
                datos.setearParametro("@rol", rol.rol);
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

        public int agregar(Rol rol)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO roles (codigo, rol) VALUES (@codigo, @rol)");
                datos.setearParametro("@codigo", rol.codigo);
                datos.setearParametro("@rol", rol.rol);
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
                datos.setearConsulta("DELETE FORM roles WHERE id= @id");
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

        public List<byte> horariosSi()
        {
            List <byte> listaId = new List<byte>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id FROM roles WHERE horariosSi = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    byte id = (byte)datos.Lector["id"];
                    listaId.Add(id);
                }
                return listaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de ROLES");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
