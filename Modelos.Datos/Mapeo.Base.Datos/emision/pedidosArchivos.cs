using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Mapeo.Base.Datos.emision
{
    [Table("[emision].[pedidosArchivos]")]
    public class pedidosArchivos
    {        
        public int id { get; set; }
        public int? idPedido { get; set; }
        public int? idUsuario { get; set; }
        public string urlArchivo { get; set; }
        public string nombreArchivo { get; set; }
    }
}
