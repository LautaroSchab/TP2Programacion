using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CUsuario
    {
        /*private string connectionString = @"Data Source=(local);Initial Catalog=DBLOSDOSCHINOS;Integrated Security=True";
        public List<USUARIO> Listar() 
        {
            List<USUARIO> listas = new List<USUARIO>();

            using (SqlConnection oconexion = new SqlConnection(connectionString)) 
            {
                
                
                    string consulta = "SELECT Documento,clave, NombreCompleto from usuario";
                    SqlCommand cmd = new SqlCommand(consulta,oconexion);
                    cmd.CommandType= CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {
                            USUARIO Lista = new USUARIO()
                            {
                            Documento = dr["Documento"].ToString(),
                            clave = dr["clave"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString()
                            
                            

                            };
                           listas.Add(Lista);
                        }
                        dr.Close();
                    } 
            }
            return listas;
        }*/

        public List<USUARIO> Listar()
        {
            List<USUARIO> listas = new List<USUARIO>();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("SELECT u.IdUsuario, u.Documento,u.NombreCompleto, u.Correo, u.clave, u.Estado,r.IdRol, r.Descripcion FROM usuario u");
                consulta.AppendLine("inner join ROL r on r.IdRol = u.IdRol");
                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        USUARIO Lista = new USUARIO()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            clave = dr["Clave"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            ORol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString()}
                            
                        };

                        listas.Add(Lista);
                    }
                    dr.Close();
                }
                return listas;
            }
            
        }
        public int Registrar (USUARIO obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int IdUsuariogenerado = 0;
            
            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena)) 
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("Documento",obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("clave", obj.clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.ORol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioresultado",SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    IdUsuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch(Exception ex)
            {

                IdUsuariogenerado = 0;
                Mensaje = ex.Message;
            
            }
            return IdUsuariogenerado;
        }


        public bool Editar (USUARIO obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("clave", obj.clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.ORol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {

                Respuesta = false;
                Mensaje = ex.Message;

            }
            return Respuesta;
        }

        public bool Eliminar (USUARIO obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {

                Respuesta = false;
                Mensaje = ex.Message;

            }
            return Respuesta;
        }
    }

}
