using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CUsuario objcd_usuario = new CUsuario();
        public List<USUARIO> Listar() 
        {
            return objcd_usuario.Listar();
        }

        public int Registrar(USUARIO obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "") 
            {
                Mensaje += "Es necesario el documento de usuario\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo de usuario\n";
            }

            if (obj.clave == "")
            {
                Mensaje += "Es necesario la clave de usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;

            }
            else 
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(USUARIO obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento de usuario\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo de usuario\n";
            }

            if (obj.clave == "")
            {
                Mensaje += "Es necesario la clave de usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;

            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
            
        }

        public bool Eliminar (USUARIO obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
    }
    
}
