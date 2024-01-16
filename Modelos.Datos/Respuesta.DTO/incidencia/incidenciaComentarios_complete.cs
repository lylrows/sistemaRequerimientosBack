using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaComentarios_complete
    {
        public int id { get; set; }
        public int idIncidencia { get; set; }
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string comentario { get; set; }
        public string imgUsuario { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
