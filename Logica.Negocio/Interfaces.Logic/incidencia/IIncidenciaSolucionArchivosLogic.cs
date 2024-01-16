using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciaSolucionArchivosLogic
    {
        bool Update(t_incidenciaSolucionArchivos obj);
        int Insert(t_incidenciaSolucionArchivos obj);
        IEnumerable<t_incidenciaSolucionArchivos> GetList();
        t_incidenciaSolucionArchivos GetById(int id);
        List<t_incidenciaSolucionArchivos> GetByIdIncSol(int id);
    }
}
