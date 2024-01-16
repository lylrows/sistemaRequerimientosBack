using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciasHistorial]")]
    public class incidenciasHistorial
    {
        public int id { get; set; }
        public int? idIncidencia { get; set; }
        public int? idUsuario { get; set; }
        public int? idEstado { get; set; }
        public DateTime? fechaRegistro { get; set; }

    }
}