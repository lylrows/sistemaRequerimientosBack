using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[parametros]")]
    public class t_parametros
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int esActivo { get; set; }
    }
}
