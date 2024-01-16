using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[sistemas]")]
    public class t_sistemas
    {
        public int id                           { get; set; }
        public string codigoSistema             { get; set; }
        public string nombreSistema             { get; set; }
        public string descripcion               { get; set; }
        public int tipoSistema                  { get; set; }
        public string descripcionTipoSistema { get; set; }
        public int intervaloAtencion { get; set; }
        public int esActivo                     { get; set; }
    }
}
