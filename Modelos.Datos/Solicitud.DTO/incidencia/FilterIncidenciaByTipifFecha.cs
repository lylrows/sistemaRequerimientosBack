using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FilterIncidenciaByFechaById
    {
        public DateTime fecha_ini { get; set; }
        public DateTime fecha_fin { get; set; }
        public int id_usuario { get; set; }
        public int id_rol { get; set; }
    }
}
