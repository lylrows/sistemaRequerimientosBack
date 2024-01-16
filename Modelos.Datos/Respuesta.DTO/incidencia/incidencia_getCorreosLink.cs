using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidencia_getCorreosLink
    {
        public int idUsuarioRegistro { get; set; }        
        public string nombresUsuarioRegistro { get; set; }
        public string apellidosUsuarioRegistro { get; set; }
        public string emailUsuarioRegistro { get; set; }
        public int idUsuarioAsignado { get; set; }
        public string nombresUsuarioAsignado { get; set; }
        public string apellidosUsuarioAsignado { get; set; }
        public string emailUsuarioAsignado { get; set; }
        public string linkIncidencias { get; set; }
    }
}
