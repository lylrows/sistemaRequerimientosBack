using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[constantes]")]
    public class t_constantes
    {
        public int id { get; set; }                
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal valor                       { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int esActivo { get; set; }
    }
}