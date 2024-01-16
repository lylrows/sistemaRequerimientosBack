using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System.Collections.Generic;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciaSolucionPalabrasClaveRepository : IRepository<t_incidenciaSolucionPalabrasClave>
    {
        List<t_incidenciaSolucionPalabrasClave> GetByIdIncSol(int id_incSol);
    }
}
