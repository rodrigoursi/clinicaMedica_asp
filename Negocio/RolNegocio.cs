﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    internal class RolNegocio
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
                    rol.id = (int)datos.Lector["id"];
                    rol.codigo = (int)datos.Lector["codigo"];
                    rol.nombre = (string)datos.Lector["rol"];


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
                datos.setearConsulta("UPDATE roles SET codigo=@codigo, rol=@nombre WHERE id=@id");
                datos.setearParametro("@id", rol.id);
                datos.setearParametro("@codigo", rol.codigo);
                datos.setearParametro("@nombre", rol.nombre);
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
                datos.setearConsulta("INSERT INTO roles (codigo, rol) VALUES (@codigo, @nombre)");
                datos.setearParametro("@codigo", rol.codigo);
                datos.setearParametro("@nombre", rol.nombre);
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
    }
}
