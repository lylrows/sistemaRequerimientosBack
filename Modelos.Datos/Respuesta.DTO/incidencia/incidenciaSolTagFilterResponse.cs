using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaSolTagFilterResponse
    {
        public int idIncidencia { get;set;}
        public int idSolucion { get;set;}
        public int idTicket { get; set; }
        public string titulo { get;set;}
        public string empresa { get; set; }
        public string sistema { get; set; }
        public string tipificacion { get; set; }
        public string solucion                     {get;set;}
        public string nombreIncidencia         {get;set;}
        public string prioridad { get; set; }
    }
}
