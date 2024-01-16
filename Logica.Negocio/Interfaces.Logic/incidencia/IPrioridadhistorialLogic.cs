using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IPrioridadhistorialLogic
    {
        bool Update(prioridadHistorial obj);
        int Insert(prioridadHistorial obj);
        IEnumerable<prioridadHistorial> GetList();
        prioridadHistorial GetById(int id);
        bool Delete(prioridadHistorial obj);
    }
}