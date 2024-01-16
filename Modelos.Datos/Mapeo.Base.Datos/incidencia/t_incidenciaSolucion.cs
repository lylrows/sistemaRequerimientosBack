using Dapper.Contrib.Extensions;
using System;

namespace Modelos.Datos.Mapeo.Base.Datos.incidencia
{
    [Table("[incidencia].[incidenciaSolucion]")]
    public class t_incidenciaSolucion
    {
        public int id                          { get; set; }
        public int idIncidencia            { get; set; }
        public int tipoSolucion            { get; set; }
        public string solucion             { get; set; }
        public string comentarios { get; set; }
    }
}
