using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciaSolucionRepository : IRepository<t_incidenciaSolucion>
    {
        List<incidenciaSolucion_complete> getIncidenciaSolucionesFilter(int id);
        List<incidenciaSolTagFilterResponse> getIncidenciasSolucionesByTagFilter(List<palabrasClave_tag> req);
        solucionDTO getSolutionById(int id);
        List<solutionImgDTO> getSolutionImg(int id);
    }
}
