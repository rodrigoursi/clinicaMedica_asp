﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    internal class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT " +
                                        "id, " +
                                        "cod_usu, " +
                                        "password, " +
                                        "nombre_apellido, " +
                                        "email, " +
                                        "tipo_documento, " +
                                        "numero_doc, " +
                                        "fecha_nacimiento, " +
                                        "direccion, " +
                                        "localidad, " +
                                        "especialidad, " +
                                        "rol, " +
                                        "altaUsu, " +
                                        "modiUsus, " +
                                        "bajaUsu, " +
                                        "altaFecha, " +
                                        "modiFecha, " +
                                        "bajaFecha " +
                                    "FROM " +
                                        "usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = (int)datos.Lector["id"];
                    usuario.codigoUsuario = (int)datos.Lector["cod_usu"];
                    usuario.password = (string)datos.Lector["password"];
                    usuario.nombreYApellido = (string)datos.Lector["nombre_apellido"];
                    usuario.emailUsuario = (string)datos.Lector["email"];
                    usuario.tipoDeDocumento = (string)datos.Lector["tipo_documento"];
                    usuario.numeroDeDocumento = (string)datos.Lector["numero_doc"];
                    usuario.fechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento"];
                    usuario.direccion = (string)datos.Lector["direccion"];
                    usuario.localidad.id = (short)datos.Lector["localidad"];
                    usuario.especialidad.id = (byte)datos.Lector["especialidad"];
                    usuario.rol.id = (byte)datos.Lector["rol"];
                    usuario.altaUsuario.id = (int)datos.Lector["altaUsu"];
                    usuario.modificacionUsuario.id = (int)datos.Lector["modiUsus"];
                    usuario.bajaUsuario.id = (int)datos.Lector["bajaUsu"];
                    usuario.altaFecha = (DateTime)datos.Lector["altaFecha"];
                    usuario.modificacionFecha = (DateTime)datos.Lector["modiFecha"];
                    usuario.bajaFecha = (DateTime)datos.Lector["bajaFecha"];


                    lista.Add(usuario);
                }

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar los datos de la tabla de USUARIOS");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int editar(Usuario usuario)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE " +
                                        "usuarios" +
                                    " SET " +
                                        "cod_usu=@codigo, " +
                                        "password=@password, " +
                                        "nombre_apellido=@nombreApellido, " +
                                        "email=@email, " +
                                        "tipo_documento=@tipoDocumento, " +
                                        "numero_doc=@numeroDocumento, " +
                                        "fecha_nacimiento=@fechaNacimiento, " +
                                        "direccion=@direccion, " +
                                        "localidad=@localidad, " +
                                        "especialidad=@especialidad, " +
                                        "rol=@rol, " +
                                        "modiUsu=@modiUsuario," +
                                        "modiFecha=@modiFecha " +
                                    "WHERE" +
                                            "id=@id");

                datos.setearParametro("@id", usuario.id);
                datos.setearParametro("@codigo", usuario.codigoUsuario);
                datos.setearParametro("@password", usuario.password);
                datos.setearParametro("@nombreApellido", usuario.nombreYApellido);
                datos.setearParametro("@email", usuario.emailUsuario);
                datos.setearParametro("@tipoDocumento", usuario.tipoDeDocumento);
                datos.setearParametro("@numeroDocumento", usuario.numeroDeDocumento);
                datos.setearParametro("@fechaNacimiento", usuario.fechaDeNacimiento);
                datos.setearParametro("@direccion", usuario.direccion);
                datos.setearParametro("@localidad", usuario.localidad.id);
                datos.setearParametro("@especialidad", usuario.especialidad.id);
                datos.setearParametro("@rol", usuario.rol.id);
                datos.setearParametro("@modiUsuario", usuario.modificacionFecha);
                datos.setearParametro("@modiFecha", usuario.modificacionFecha);
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

        public int agregar(Usuario usuario)
        {
            int resultado = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO " +
                                        "usuarios (" +
                                        "cod_usu, " +
                                        "password, " +
                                        "nombre_apellido, " +
                                        "email, " +
                                        "tipo_documento, " +
                                        "numero_doc, " +
                                        "fecha_nacimiento, " +
                                        "direccion, " +
                                        "localidad, " +
                                        "especialidad, " +
                                        "rol, " +
                                        "altaUsu, " +
                                        "modiUsus, " +
                                        "bajaUsu, " +
                                        "altaFecha, " +
                                        "modiFecha, " +
                                        "bajaFecha) " +
                                    "VALUES " +
                                        "(@codigo," +
                                        "@password," +
                                        "@nombreApellido," +
                                        "@observaciones," +
                                        "@email," +
                                        "@tipoDocumento," +
                                        "@numeroDocumento," +
                                        "@fechaNacimiento," +
                                        "@direccion," +
                                        "@localidad," +
                                        "@especialidad," +
                                        "@rol," +
                                        "@modiUsuario," +
                                        "@modiFecha)");

                datos.setearParametro("@id", usuario.id);
                datos.setearParametro("@codigo", usuario.codigoUsuario);
                datos.setearParametro("@password", usuario.password);
                datos.setearParametro("@nombreApellido", usuario.nombreYApellido);
                datos.setearParametro("@email", usuario.emailUsuario);
                datos.setearParametro("@tipoDocumento", usuario.tipoDeDocumento);
                datos.setearParametro("@numeroDocumento", usuario.numeroDeDocumento);
                datos.setearParametro("@fechaNacimiento", usuario.fechaDeNacimiento);
                datos.setearParametro("@direccion", usuario.direccion);
                datos.setearParametro("@localidad", usuario.localidad.id);
                datos.setearParametro("@especialidad", usuario.especialidad.id);
                datos.setearParametro("@rol", usuario.rol.id);
                datos.setearParametro("@modiUsuario", usuario.modificacionFecha);
                datos.setearParametro("@modiFecha", usuario.modificacionFecha);
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
                datos.setearConsulta("DELETE FORM usuarios WHERE id= @id");
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