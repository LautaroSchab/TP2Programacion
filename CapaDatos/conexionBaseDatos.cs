using System.Configuration;


namespace CapaDatos
{
    public class conexionBaseDatos
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["sql_conexion"].ToString();
    }
}
