using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[empresaSistemas]")]
    public class t_empresaSistemas
    {
        public int id                 { get; set; }
        public int idEmpresa      { get; set; }
        public int idSistema { get; set; }
        public int horasContratadas { get; set; }
        public decimal intervaloAtencion { get; set; }
    }
}
