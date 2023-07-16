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
                datos.setearConsulta("SELECT id, codigo, rol, horariosSi, permisosConfiguracion, permisosFichas, permisosModificarTurno, permisosSoloTurnosPropios FROM roles");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Rol rol = new Rol();
                    rol.id = (byte)datos.Lector["id"];
                    rol.codigo = (string)datos.Lector["codigo"];
                    rol.rol = (string)datos.Lector["rol"];
                    rol.horariosSi = (bool)datos.Lector["horariosSi"];
                    rol.permisosConfiguracion = (bool)datos.Lector["permisosConfiguracion"];
                    rol.permisosFichas = (bool)datos.Lector["permisosFichas"];
                    rol.permisosModificarTurno = (bool)datos.Lector["permisosModificarTurno"];
                    rol.permisosSoloTurnosPropios = (bool)datos.Lector["permisosSoloTurnosPropios"];

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
                datos.setearConsulta("UPDATE roles SET codigo=@codigo, rol=@rol, horariosSi=@horariosSi, permisosConfiguracion=@p1, permisosFichas=@p2, permisosModificarTurno=@p3, permisosSoloTurnosPropios=@p4 WHERE id=@id");
                datos.setearParametro("@id", rol.id);
                datos.setearParametro("@codigo", rol.codigo);
                datos.setearParametro("@rol", rol.rol);
                datos.setearParametro("@horariosSi", rol.horariosSi);
                datos.setearParametro("@p1", rol.permisosConfiguracion);
                datos.setearParametro("@p2", rol.permisosFichas);
                datos.setearParametro("@p3", rol.permisosModificarTurno);
                datos.setearParametro("@p4", rol.permisosSoloTurnosPropios);

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
                datos.setearConsulta("INSERT INTO roles (codigo, rol, horariosSi, permisosConfiguracion, permisosFichas, permisosModificarTurno, permisosSoloTurnosPropios) VALUES (@codigo, @rol, @horariosSi, @p1, @p2, @p3, @p4)");
                datos.setearParametro("@codigo", rol.codigo);
                datos.setearParametro("@rol", rol.rol);
                datos.setearParametro("@horariosSi", rol.horariosSi);
                datos.setearParametro("@p1", rol.permisosConfiguracion);
                datos.setearParametro("@p2", rol.permisosFichas);
                datos.setearParametro("@p3", rol.permisosModificarTurno);
                datos.setearParametro("@p4", rol.permisosSoloTurnosPropios);
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
                datos.setearConsulta("DELETE FROM roles WHERE id= @id");
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

        public Rol RolDeUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT TOP 1 id, codigo, rol, horariosSi, permisosConfiguracion, permisosFichas, permisosModificarTurno, permisosSoloTurnosPropios FROM roles WHERE roles.id = @idRolUsuario");
                datos.setearParametro("@idRolUsuario", usuario.rol.id);

                datos.ejecutarLectura();

                Rol rol = new Rol();
                while (datos.Lector.Read())
                {
                    rol.id = (byte)datos.Lector["id"];
                    rol.codigo = (string)datos.Lector["codigo"];
                    rol.rol = (string)datos.Lector["rol"];
                    rol.horariosSi = (bool)datos.Lector["horariosSi"];
                    rol.permisosConfiguracion = (bool)datos.Lector["permisosConfiguracion"];
                    rol.permisosFichas = (bool)datos.Lector["permisosFichas"];
                    rol.permisosModificarTurno = (bool)datos.Lector["permisosModificarTurno"];
                    rol.permisosSoloTurnosPropios = (bool)datos.Lector["permisosSoloTurnosPropios"];

                    // Imprimir los valores para verificar
                    Debug.WriteLine($"id: {rol.id}, codigo: {rol.codigo}, nombre: {rol.rol}");

                }

                return rol;
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
