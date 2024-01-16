using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.mejora
{
    [Table("[mejora].[mejoraArchivos]")]
    public class t_mejoraArchivos
    {
        public int id { get; set; }
        public int idMejora { get; set; }
        public int idUsuario { get; set; }
        public string urlArchivo { get; set; }
        public string nombreArchivo { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
