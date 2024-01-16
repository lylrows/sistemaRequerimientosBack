using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.empresas
{
    [Table("[empresas].[tipificacionesEmpresa]")]
    public class tipificacionesEmpresa
    {
        public int id { get; set; }
        public int? idEmpresa { get; set; }
        public int? idTipificacion { get; set; }
    }
}