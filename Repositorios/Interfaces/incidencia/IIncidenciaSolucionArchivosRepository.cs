using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System.Collections.Generic;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciaSolucionArchivosRepository : IRepository<t_incidenciaSolucionArchivos>
    {
        List<t_incidenciaSolucionArchivos> GetByIdIncSol(int id_incSol);
    }
}
