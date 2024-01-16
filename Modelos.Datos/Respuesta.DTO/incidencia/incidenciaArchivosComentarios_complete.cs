using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaArchivosComentarios_complete
    {
        public incidencia_getComplete incidencia { get; set; }
        public List<incidenciaArchivos_complete> lstArchivos { get; set; }
        public List<incidenciaComentarios_complete> lstComentarios { get; set; }
    }
}
