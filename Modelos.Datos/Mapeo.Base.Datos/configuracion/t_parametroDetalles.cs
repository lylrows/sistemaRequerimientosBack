using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[parametroDetalles]")]
    public class t_parametroDetalles
    {
        public int id                     { get; set; }
        public int idParametro { get; set; }
        public string codigo              { get; set; }
        public string nombre              { get; set; }
        public string valor { get; set; }
        public int valorEntero { get; set; }
        public string valorAuxiliar { get; set; }
        public int idParametroPadre { get; set; }
        public int esActivo { get; set; }
    }
}
