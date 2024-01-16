using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.persona
{
    [Table("[persona].[personas]")]
    public class personas
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
        public string telefono                  { get; set; }
        public string celular                   { get; set; }
        public string img { get; set; }
        public int? esActivo     { get; set; }
        public int primeraVez { get; set; }
        public bool? isGerente { get; set; } 
    }
}
