using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.emision
{
    [Table("[emision].[pedidosRespuesta]")]
    public class pedidosRespuesta
    {
        public int id { get; set; }
        public int? idPedido { get; set; }
        public string titulo { get; set; }
        public string comentario { get; set; }
    }
}
