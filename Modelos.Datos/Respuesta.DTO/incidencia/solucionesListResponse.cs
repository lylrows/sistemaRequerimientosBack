using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class solucionesListResponse
    {
        public int idSolucion { get; set; }
        public int idIncidencia                                  {get;set;}
        public string nombreIncidencia                           {get;set;}
        public string tipoSolucion                               {get;set;}
        public string tipificacion                               {get;set;}
        public string solucion                                   {get;set;}
        public string comentarios                                {get;set;}
        public List<t_incidenciaSolucionPalabrasClave> palabraClave    {get;set;}
        public List<t_incidenciaSolucionArchivos> palabrasArchivos     {get;set;}

    }
}
