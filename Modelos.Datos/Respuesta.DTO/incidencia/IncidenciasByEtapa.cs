using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class IncidenciasByEtapa
    {
        public List<int> conteo { get; set; }
        public List<int> porcentaje { get; set; }
        public IncidenciasByEtapa()
        {
            conteo = new List<int>();
            porcentaje = new List<int>();
        }
    }
}
