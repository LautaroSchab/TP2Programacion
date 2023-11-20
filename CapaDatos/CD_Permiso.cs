using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        
        
        private string connectionString = @"Data Source=(local);Initial Catalog=DBLOSDOSCHINOS;Integrated Security=True";
        public List<Permiso> Listar(int IdUsuario)
        {
            List<Permiso> listas = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(connectionString))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p");
                consulta.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                consulta.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                consulta.AppendLine("where u.IdUsuario= @IdUsuario");

                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Permiso Lista = new Permiso()
                        {
                            ORol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                            NombreMenu = dr["NombreMenu"].ToString(),



                        };
                        listas.Add(Lista);
                    }
                    dr.Close();
                }
            }
            return listas;
        }
    }
}
