using Dapper.Contrib.Extensions;
namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[empresaSistemaUsuarios]")]
    public class t_empresaSistemaUsuarios
    {
        public int id                      { get; set; }
        public int idEmpresaSistemas       { get; set; }
        public int idUsuario { get; set; }
        public int idNivelSoporte { get; set; }
        public int esActivo { get; set; }
    }
}
