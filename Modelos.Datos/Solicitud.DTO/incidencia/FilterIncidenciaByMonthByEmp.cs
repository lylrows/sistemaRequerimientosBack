using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Solicitud.DTO.incidencia
{
    public class FilterIncidenciaByMonthByEmp
    {
        public int anho { get; set; }
        public int mes { get; set; }
        public int id_empresa { get; set; }
        public string rol { get; set; }
    }
}
