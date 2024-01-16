using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class IncidenciaGetTable1
    {
        public string date { get; set; }
        public string indicador { get; set; }
        public float mejoras { get; set; }
        public float soporte { get; set; }
        public float errores { get; set; }
        public float garantia { get; set; }
        public float total { get; set; }
    }
}
