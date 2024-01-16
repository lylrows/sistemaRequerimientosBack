using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciaAsignaciones]")]
    public class t_incidenciaAsignaciones
    {
        public int id                            { get; set; }
            public int idIncidencia              { get; set; }
            public int idUsuarioOrigen           { get; set; }
            public int idUsuaroAsignado          { get; set; }
            public int idUsuarioEscalar { get; set; }
            public int esActivo { get; set; }
    }
}
