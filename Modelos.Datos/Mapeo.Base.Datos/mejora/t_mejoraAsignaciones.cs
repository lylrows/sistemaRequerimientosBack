using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.mejora
{
    [Table("[mejora].[mejoraAsignaciones]")]
    public class t_mejoraAsignaciones
    {
        public int id { get; set; }
        public int idMejora { get; set; }
        public int idUsuariOrigen { get; set; }
        public int idUsuarioAsignado { get; set; }
        public int esActivo { get; set; }
    }
}
