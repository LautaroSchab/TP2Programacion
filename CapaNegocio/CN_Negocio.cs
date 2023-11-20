using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcd_Negocio = new CD_Negocio();
        public Negocio ObtenerDatos()
        {
            return objcd_Negocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre\n";
            }
            if (obj.RUC == "")
            {
                Mensaje += "Es necesario el numero de RUC\n";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario la direccion\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;

            }
            else
            {
                return objcd_Negocio.GuardarDatos(obj, out Mensaje);
            }
        }

        public byte[] ObtenerLogo(out  bool Obtenido)
        {
            return objcd_Negocio.ObtenerLogo(out Obtenido);
        }

        public bool ActualizarLogo (byte[] Imagen,out string Mensaje)
        {
            return objcd_Negocio.ActualizarLogo(Imagen,out Mensaje);
        }
    }
}
