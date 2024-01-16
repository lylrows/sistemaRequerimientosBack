using Modelos.Datos.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaByTipifListDecimal
    {
        public List<string> data { get; set; }
        public List<seriesReqDecimal> series { get; set; }
        public incidenciaByTipifListDecimal()
        {
            data = new List<string>();
            series = new List<seriesReqDecimal>();
        }
    }
}
