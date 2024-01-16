using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciaComentarios]")]
    public class t_incidenciaComentarios
    {
        public int id                    { get; set; }
        public int idIncidencia      { get; set; }
        public int idUsuario         { get; set; }
        public string comentario { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
