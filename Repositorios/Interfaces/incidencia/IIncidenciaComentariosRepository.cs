using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciaComentariosRepository : IRepository<t_incidenciaComentarios>
    {
        IEnumerable<comentariosByIdincidenciaDTO> getComentariosByIdincidencia(in int id);
    }
}
