using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using System.Collections.Generic;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciaArchivosRepository : IRepository<t_incidenciaArchivos>
    {
        public List<incidenciaArchivos_complete> getArchivosByIncidencia(int id);
    }
}
