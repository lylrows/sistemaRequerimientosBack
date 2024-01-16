using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaArchivos_complete
    {
        public int id { get; set; }
        public int idIncidencia { get; set; }
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string urlArchivo { get; set; }
        public string nombreArchivo { get; set; }
        public DateTime fechaRegistro { get; set; }

        public string img { get; set; }
    }
}
