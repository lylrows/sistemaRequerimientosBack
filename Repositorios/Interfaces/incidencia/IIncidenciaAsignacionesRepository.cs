using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciaAsignacionesRepository : IRepository<t_incidenciaAsignaciones>
    {
        void borrarAsignaciones(in int IdIncidencia);
        IEnumerable<nivelSoporteDTO> getNivelSoporteById(in int id);
        personas getUsuarioASignado(in int objIdIncidencia);
        personas getUsuarioRegistro(in int objIdIncidencia);
        incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int objIdIncidencia);
        int getTicketsPendientes(int id);
    }
}
