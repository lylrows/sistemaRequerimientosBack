using Modelos.Datos.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class seriesAtencionSolicitudes
    {
        public List<string> rangoFechas { get; set; }
        public List<dataLabelReq> series { get; set; }
        public seriesAtencionSolicitudes()
        {
            rangoFechas = new List<string>();
            series = new List<dataLabelReq>();
        }
    }
}
