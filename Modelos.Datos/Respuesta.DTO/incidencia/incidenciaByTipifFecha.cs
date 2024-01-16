using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaByTipifFecha
    {
        public int cantidad { get; set; }
        public int idTipificacion { get; set; }
        public string tipificacion { get; set; }
        public DateTime fecha_ini { get; set; }
        public DateTime fecha_fin { get; set; }
    }
}
