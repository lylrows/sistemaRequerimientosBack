using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.secuencial
{
    [Table("[secuencial].[tablas]")]
    public class tablas
    {
        public int id { get; set; }
        public string nombreTabla { get; set; }
    }
}
