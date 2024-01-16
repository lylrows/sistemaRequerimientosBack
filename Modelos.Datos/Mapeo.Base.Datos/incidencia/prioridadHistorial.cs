using System;
using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[prioridadHistorial]")]
    public class prioridadHistorial
    {
        public int id { get; set; }
        public int idIncidencia { get; set; }
        public int? idUsuario { get; set; }
        public int? idPrioridadInicial { get; set; }
        public int? idPrioridadFinal { get; set; }
        public string motivo { get; set; }
        public DateTime? fechaRegistro { get; set; }
    }
}