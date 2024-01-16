using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidencia_dataIntLabelString
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<int> data { get; set; }
        
        public incidencia_dataIntLabelString()
        {
            data = new List<int>();
        }
    }
}
