using Dapper.Contrib.Extensions;

namespace Servicio.Alertas.SGR.Models
{
    public class personas
    {
        [Table("[persona].[personas]")]
        public class Personas
        {
            public int id { get; set; }
            public int idPerfil { get; set; }
            public int idEmpresa { get; set; }
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public string email { get; set; }
            public int? tipoDocumento { get; set; }
            public string nroDocumento { get; set; }
            public string direccion { get; set; }
            public string telefono { get; set; }
            public string celular { get; set; }
            public string img { get; set; }
            public int? esActivo { get; set; }
        }
    }
}