using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> listas = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("select IdProducto,Codigo,Nombre,p.descripcion,c.IdCategoria, c.descripcion[Descripcioncategoria],stock,PrecioCompra,PrecioVenta,p.Estado from Producto p");
                consulta.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");
                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Producto Lista = new Producto()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Codigo = dr["Codigo"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["descripcion"].ToString(),
                            OCategoria = new Categoria() {IdCategoria = Convert.ToInt32(dr["IdProducto"]),Descripcion = dr["DescripcionCategoria"].ToString(), } ,
                            Stock = Convert.ToInt32(dr["stock"].ToString()),
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString())


                        

                        };

                        listas.Add(Lista);
                    }
                    dr.Close();
                }
                return listas;
            }

        }
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int IdProductogenerado = 0;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPRODUCTO", oconexion);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.OCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    IdProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {

                IdProductogenerado = 0;
                Mensaje = ex.Message;

            }
            return IdProductogenerado;
        }


        public bool Editar(Producto obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARPRODUCTO", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.OCategoria.IdCategoria);
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

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexionBaseDatos.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPRODUCTO", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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
