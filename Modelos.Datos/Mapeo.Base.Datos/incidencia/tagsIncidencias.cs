using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[tagsIncidencias]")]
    public class tagsIncidencias
    {        
        public int id { get; set; }
        public int? idTag { get; set; }
        public int? idIncidencia { get; set; }
        public bool? solucionRaiz { get; set; }
    }
}
