using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class IncidenciaHorasUsuarioAsignadoSistemaByMonth
    {
        public string nombres           {get;set;}
            public string nombreSistema {get;set;}
            public string tipo          {get;set;}
            public int tickets          {get;set;}
            public float hrsUsadas      {get;set;}
            public int mes { get; set; }
    }
}
