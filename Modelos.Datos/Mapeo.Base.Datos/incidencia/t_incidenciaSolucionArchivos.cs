using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciaSolucionArchivos]")]
    public class t_incidenciaSolucionArchivos
    {
        public int id                           {get;set;}
            public int idIncidenciaSolucion     {get;set;}
            public int idUsuario                {get;set;}
            public string urlArchivo            {get;set;}
            public string nombreArchivo { get; set; }
    }
}
