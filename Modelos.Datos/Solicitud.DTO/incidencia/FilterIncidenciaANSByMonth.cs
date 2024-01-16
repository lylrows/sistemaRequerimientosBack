using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FilterIncidenciaANSByMonth
    {
        public int anho { get; set; }
        public int id_usuario { get; set; }
        public int mesFinANS { get; set; }
        public int mesIniANS { get; set; }
        public string rol { get; set; }
    }
}
