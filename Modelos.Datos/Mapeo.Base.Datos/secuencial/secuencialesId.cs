using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.secuencial
{
    [Table("[secuencial].[secuencialesId]")]
    public class secuencialesId
    {
        public int id { get; set; }
        public int? idEmpresa { get; set; }
        public int? idTabla { get; set; }
        public int? idSecuencial { get; set; }
    }
}
