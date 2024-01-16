using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class GetIncidenciaArchivosComentarios
    {
        public t_incidencias incidencia { get; set; }
        public List<t_incidenciaArchivos> lstArchivos { get; set; }
        public List<t_incidenciaComentarios> lstComentarios { get; set; }
    }
}
