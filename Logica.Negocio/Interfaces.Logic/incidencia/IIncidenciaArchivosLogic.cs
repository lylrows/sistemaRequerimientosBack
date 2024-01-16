using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using System;
using System.Collections.Generic;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciaArchivosLogic
    {
        bool Update(t_incidenciaArchivos obj);
        int Insert(t_incidenciaArchivos obj);
        IEnumerable<t_incidenciaArchivos> GetList();
        t_incidenciaArchivos GetById(int id);
        List<incidenciaArchivos_complete> getArchivosByIncidencia(int id);
    }
}
