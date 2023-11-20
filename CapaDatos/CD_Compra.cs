using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace CapaDatos
{
    public class CD_Compra
    {
        public int ObtenerCorrelativo() 
        {
            int IdCorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {

                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select count(*) + 1 from COMPRA");
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

        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje) 
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCOMPRA", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.OUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.OProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
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

        public Compra ObtenerCompra(string numero) 
        {
            Compra obj = new Compra();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                try
                {

                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select c.IdCompra,");
                    consulta.AppendLine("u.NombreCompleto,");
                    consulta.AppendLine(" pr.Documento, pr.RazonSocial,");
                    consulta.AppendLine("c.TipoDocumento,c.NumeroDocumento,c.MontoTotal, convert(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    consulta.AppendLine("from COMPRA c");
                    consulta.AppendLine("inner join USUARIO u on u.IdUsuario = c.IdUsuario");
                    consulta.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    consulta.AppendLine("where c.NumeroDocumento = @Numero");

                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Numero", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                OUsuario = new USUARIO() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                OProveedor = new Proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }

                    }
                }
                catch (Exception ex) 
                {

                    obj = new Compra();
                }                
            }
            return obj;      
        }

        public List<Detalle_Compra> ObtenerDetalleCompra(int IdCompra) 
        {
            List<Detalle_Compra> OList = new List<Detalle_Compra>();

            try 
            {
                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena)) 
                {
                    oconexion.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.AppendLine("select p.Nombre, dc.PrecioCompra,dc.Cantidad,dc.MontoTotal from DETALLE_COMPRA dc");
                    consulta.AppendLine("inner join Producto p on p.IdProducto = dc.IdProducto");
                    consulta.AppendLine("where dc.IdCompra = @IdCompra");

                    SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdCompra", IdCompra);
                    cmd.CommandType = System.Data.CommandType.Text;
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            OList.Add(new Detalle_Compra()
                            {                               
                                OProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                
                            });
                        }

                    }
                }


            } 
            catch (Exception ex) 
            {
            
                OList = new List<Detalle_Compra>();
            
            
            }
            return OList;
        
        
        
        
        }

    }
}
