using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    oconexion.Open();
                    string consulta = "select IdNegocio, Nombre, RUC, Direccion from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(consulta, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj.IdNegocio = int.Parse(dr["IdNegocio"].ToString());
                            obj.Nombre = dr["Nombre"].ToString();
                            obj.RUC = dr["RUC"].ToString();
                            obj.Direccion = dr["Direccion"].ToString();
                        }
                    }
                }
            }
            catch
            {
                obj = new Negocio();
            }

            return obj;
        }

        /*public Negocio ObtenerDatos() 
        { 
            Negocio obj = new Negocio();

            try 
            {
                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena)) 
                {
                    oconexion.Open();
                    string consulta = "select IdNegocio,Nombre, RUC, Direccion from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(consulta,oconexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RUC = dr["RUC "].ToString(),
                                Direccion = dr["Direccion"].ToString(),


                            };
                        }
                    
                    }
                }
            
            } 
            catch 
            {
                obj = new Negocio();
            
            }



            return obj;
        }*/

        public bool  GuardarDatos(Negocio objeto, out  string Mensaje) 
        {
            Mensaje = string.Empty;
            bool Respuesta = true;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    oconexion.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("update NEGOCIO set Nombre = @Nombre,");
                    consulta.AppendLine("RUC = @RUC,");
                    consulta.AppendLine("Direccion = @Direccion");
                    consulta.AppendLine("where IdNegocio = 1");

                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@RUC", objeto.RUC);
                    cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1) 
                    {
                        Mensaje = "No se pudo guardar los datos";
                        Respuesta = false;
                    
                    
                    }

               
                }

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Respuesta = false;


            }
            return Respuesta;
        }

        public byte[] ObtenerLogo(out bool Obtenido) 
        {
            Obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    oconexion.Open();
                    
                    string consulta = "select Logo from NEGOCIO where IdNegocio = 1";
                   

                    SqlCommand cmd = new SqlCommand(consulta, oconexion);
                    
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (Byte[])dr["Logo"];

                        }

                    }


                }

            }
            catch (Exception ex)
            {
                Obtenido = false;
                LogoBytes = new byte[0];


            }
            return LogoBytes;
        }

        public bool ActualizarLogo(byte[]image,out string Mensaje) 
        {
            Mensaje = string.Empty;
            bool Respuesta = true;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    oconexion.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("update NEGOCIO set Logo = @Imagen");
                    consulta.AppendLine("where IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Imagen",image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        Mensaje = "No se pudo actualizar el logo";
                        Respuesta = false;


                    }


                }

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Respuesta = false;


            }
            return Respuesta;

        }
    }
}
