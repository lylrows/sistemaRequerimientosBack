using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[mural]")]
    public class mural
    {
        public int id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public string urlFile { get; set; }
    }
}
