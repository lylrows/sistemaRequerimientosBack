using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface ITagsincidenciasLogic
    {
        bool Update(tagsIncidencias obj);
        int Insert(tagsIncidencias obj);
        IEnumerable<tagsIncidencias> GetList();
        tagsIncidencias GetById(int id);
        bool Delete(tagsIncidencias obj);
        IEnumerable<tags> getTagListByIdIncidencia(int id);
        IEnumerable<tagsIncidenciaDTO> getTagsByIncidencias(filterDataMejorasDTO obj);
    }
}
