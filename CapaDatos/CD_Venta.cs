using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Venta
    {
        public int ObtenerCorrelativo()
        {
            int IdCorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {

                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select count(*) + 1 from VENTA");
                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    IdCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    IdCorrelativo = 0;
                }
            }
            return IdCorrelativo;

        }

        public bool RestarStock(int IdProducto, int Cantidad)
        {
            bool Respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {

                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("update Producto set Stock = Stock - @Cantidad where IdProducto = @IdProducto");
                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch
                {
                    Respuesta = false;
                }
            }
            return Respuesta;

        }
        public bool SumarStock(int IdProducto, int Cantidad)
        {
            bool Respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {

                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("update Producto set Stock = Stock + @Cantidad where IdProducto = @IdProducto");
                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);

                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    Respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch
                {
                    Respuesta = false;
                }
            }
            return Respuesta;

        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_REGISTRARVENTA", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.OUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);

                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();


                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)

                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return Respuesta;
        }

        public Venta ObtenerVenta(string numero) 
        {
            Venta obj = new Venta();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena)) 
            {
                try 
                {
                    oconexion.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select v.IdVenta,u.NombreCompleto,");
                    consulta.AppendLine("v.DocumentoCliente, v.NombreCliente,");
                    consulta.AppendLine("v.TipoDocumento,v.NumeroDocumento,");
                    consulta.AppendLine("v.MontoPago,v.MontoCambio,v.MontoTotal,");
                    consulta.AppendLine("convert(char(10),v.FechaRegistro,103)[FechaRegistro]");
                    consulta.AppendLine("from VENTA v");
                    consulta.AppendLine("inner join USUARIO u on u.IdUsuario = v.IdUsuario");
                    consulta.AppendLine("where v.NumeroDocumento = @numero");
                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {

                            obj = new Venta()
                            {
                                IdVenta= int.Parse(dr["IdVenta"].ToString()),
                                OUsuario = new USUARIO() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                DocumentoCliente= dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago= Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };

                        }
                    
                    
                    }



                }
                catch (Exception ex) 
                {
                    obj = new Venta();
                
                }
            
            
            
            
            }
          return obj;

        }

        public List<Detalle_Venta> ObtenerDetalleVenta(int IdVenta) 
        {
            List<Detalle_Venta> OList = new List<Detalle_Venta>();
            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select p.Nombre, dv.PrecioVenta, dv.Cantidad,dv.SubTotal");
                    consulta.AppendLine("from DETALLE_VENTA dv");
                    consulta.AppendLine("inner join Producto p on p.IdProducto = dv.IdProducto");
                    consulta.AppendLine("where dv.IdVenta = @IdVenta");

                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Idventa", IdVenta);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            OList.Add(new Detalle_Venta()
                            {  
                                OProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta= Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                                
                            });

                        }

                    }
                }
                catch (Exception ex)
                {
                    OList = new List<Detalle_Venta>();

                }
            }
            return OList;
        
        }
    }
}
