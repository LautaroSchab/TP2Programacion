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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> listas = new List<Proveedor>();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("select IdProveedor, Documento,RazonSocial,Correo, Telefono, Estado from PROVEEDOR");
                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Proveedor Lista = new Proveedor()
                        {
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            Documento = dr["Documento"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
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
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int IdProveedorgenerado = 0;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPROVEEDOR", oconexion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    IdProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {

                IdProveedorgenerado = 0;
                Mensaje = ex.Message;

            }
            return IdProveedorgenerado;
        }


        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARPROVEEDOR", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
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

        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPROVEEDOR", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
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
