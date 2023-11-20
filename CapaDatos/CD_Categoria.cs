using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Categoria
    {

        public List<Categoria> Listar()
        {
            List<Categoria> listas = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("SELECT IdCategoria,Descripcion,Estado FROM CATEGORIA");
                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Categoria Lista = new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"])

                        };

                        listas.Add(Lista);
                    }
                    dr.Close();
                }
                return listas;
            }

        }
        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int IdCategoriagenerado = 0;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCATEGORIA", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    IdCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {

                IdCategoriagenerado = 0;
                Mensaje = ex.Message;

            }
            return IdCategoriagenerado;
        }


        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
