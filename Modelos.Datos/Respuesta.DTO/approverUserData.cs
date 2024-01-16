using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    public class approverUserData
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string usuarioAsignado { get; set; }
        public string soporteAsignado { get; set; }
        public string email { get; set; }
        public string emailSoporte { get; set; }
    }
}
