using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciaSolucionLogic
    {
        bool Update(t_incidenciaSolucion obj);
        int Insert(incidenciaSolArchivosPalabras obj);
        int Insert(t_incidenciaSolucion obj);
        IEnumerable<t_incidenciaSolucion> GetList();
        incidenciaSolArchivosPalabras GetById(int id);
        List<incidenciaSolucion_complete> getIncidenciaSolucionesFilter(int id);
        List<incidenciaSolTagFilterResponse> getIncidenciasSolucionesByTagFilter(List<palabrasClave_tag> req);
        solucionDTO getSolutionById(int id);
        List<solutionImgDTO> getSolutionImg(int id);
    }
}
