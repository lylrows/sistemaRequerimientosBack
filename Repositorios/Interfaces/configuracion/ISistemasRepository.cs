using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.configuracion
{
    public interface ISistemasRepository : IRepository<t_sistemas>
    {
        int validaSistema(in int id);
        IEnumerable<noAsignadosDTO> getSistemasNoAsociados(in int id);
    }
}
