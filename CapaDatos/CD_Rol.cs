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
    public class CD_Rol
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=DBLOSDOSCHINOS;Integrated Security=True";
        public List<Rol> Listar()
        {
            List<Rol> listas = new List<Rol>();

            using (SqlConnection oconexion = new SqlConnection(connectionString))
            {
                StringBuilder consulta = new StringBuilder();
                consulta.AppendLine("select IdRol, Descripcion from ROL");
                

                SqlCommand cmd = new SqlCommand(consulta.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Rol Lista = new Rol()
                        {
                            IdRol= Convert.ToInt32(dr["IdRol"]),
                            Descripcion= dr["Descripcion"].ToString(),
                            



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
