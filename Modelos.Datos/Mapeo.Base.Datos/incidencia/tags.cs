using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[tags]")]
    public class tags
    {       
        public int id { get; set; }
        public string nombreTag { get; set; }
    }
}
