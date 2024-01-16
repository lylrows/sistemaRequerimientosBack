using Modelos.Datos.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaByTipifList
    {
        public List<string> data { get; set; }
        public List<seriesReq> series { get; set; }
        public incidenciaByTipifList()
        {
            data = new List<string>();
            series = new List<seriesReq>();
        }
    }
}
