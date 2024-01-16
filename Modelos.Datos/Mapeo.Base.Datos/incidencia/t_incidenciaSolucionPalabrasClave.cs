using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciaSolucionPalabrasClave]")]
    public class t_incidenciaSolucionPalabrasClave
    {
            public int id                          {get;set;}
            public int idIncidenciaSolucion    {get;set;}
            public  string palabraClave  { get; set; }
    }
}
