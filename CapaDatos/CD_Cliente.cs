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
    public class CD_Cliente
    {

        public List<Cliente> Listar()
        {
            List<Cliente> listas = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("select IdCliente,Documento, NombreCompleto,Correo, Telefono, Estado from CLIENTE");
                
                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente Lista = new Cliente()
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                             

                        };

                        listas.Add(Lista);
                    }
                    dr.Close();
                }
                return listas;
            }

        }
        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int IdClientegenerado = 0;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCLIENTE", oconexion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    IdClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {

                IdClientegenerado = 0;
                Mensaje = ex.Message;

            }
            return IdClientegenerado;
        }


        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARCLIENTE", oconexion);
                    cmd.Parameters.AddWithValue("Idcliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
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

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("delete from CLIENTE  where IdCliente = @Id", oconexion);
                    cmd.Parameters.AddWithValue("@Id", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    Respuesta = cmd.ExecuteNonQuery() > 0? true : false;
                    

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
