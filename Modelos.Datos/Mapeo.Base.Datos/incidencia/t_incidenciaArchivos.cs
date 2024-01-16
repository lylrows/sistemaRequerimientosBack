using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciaArchivos]")]
    public class t_incidenciaArchivos
    {
        public int id                        { get; set; }
            public int idIncidencia          { get; set; }
            public int idUsuario             { get; set; }
            public string urlArchivo         { get; set; }
            public string nombreArchivo { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
