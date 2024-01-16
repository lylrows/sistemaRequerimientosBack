using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaByTipifFecha_sol
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<int> data { get; set; }
        public incidenciaByTipifFecha_sol()
        {
            data = new List<int>();
        }
    }
}
