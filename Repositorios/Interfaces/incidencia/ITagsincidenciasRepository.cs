using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorios.Interfaces.incidencia
{
    public interface ITagsincidenciasRepository : IRepository<tagsIncidencias>
    {
        IEnumerable<tags> getTagListByIdIncidencia(int id);
        IEnumerable<tagsIncidenciaDTO> getTagsByIncidencias(filterDataMejorasDTO obj);
    }
}
