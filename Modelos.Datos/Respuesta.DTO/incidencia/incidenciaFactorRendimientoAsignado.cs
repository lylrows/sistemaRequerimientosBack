using Modelos.Datos.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaFactorRendimientoAsignado
    {
        public string name { get; set; }
        public List<SeriesStrInt> series { get; set; }
    }
}
