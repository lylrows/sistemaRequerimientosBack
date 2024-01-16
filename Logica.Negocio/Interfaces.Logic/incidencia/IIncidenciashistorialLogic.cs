using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciashistorialLogic
    {
        bool Update(incidenciasHistorial obj);
        int Insert(incidenciasHistorial obj);
        IEnumerable<incidenciasHistorial> GetList();
        incidenciasHistorial GetById(int id);
        bool Delete(incidenciasHistorial obj);
    }
}