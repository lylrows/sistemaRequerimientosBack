using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;

namespace Modelos.Datos.Respuesta.DTO.incidencia
{
    public class incidenciaSolArchivosPalabras
    {
        public t_incidenciaSolucion           incidenciaSol           {get;set;}
        public List<t_incidenciaSolucionArchivos>    lstIncidenciaSolArchivos   {get;set;}
        public List<t_incidenciaSolucionPalabrasClave> lstIncidenciaSolPalabras  { get; set; }
    }
}
