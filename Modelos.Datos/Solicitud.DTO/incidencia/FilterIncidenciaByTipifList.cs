
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FilterIncidenciaByTipifList
    {
        public List<int> idTipificacion { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public int id_usuario { get; set; }
        public int id_rol { get; set; }
    }
}
