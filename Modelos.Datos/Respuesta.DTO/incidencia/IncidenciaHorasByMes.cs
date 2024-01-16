using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class IncidenciaHorasByMes
    {
        public string Tipo { get; set; }
        public int Tickets { get; set; }
        public float HrsUsadas { get; set; }
        public int Mes { get; set; }
    }
}
