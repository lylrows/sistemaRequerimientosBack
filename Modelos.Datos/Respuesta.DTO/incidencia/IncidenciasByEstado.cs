using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class IncidenciasByEstado
    {
        public List<string> estados { get; set; }
        public List<int> conteo { get; set; }
        public IncidenciasByEstado()
        {
            estados = new List<string>();
            conteo = new List<int>();
        }
    }
}
