using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using Modelos.Datos.Solicitud.DTO;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciaSolucionPalabrasClaveLogic
    {
        bool Update(t_incidenciaSolucionPalabrasClave obj);
        int Insert(t_incidenciaSolucionPalabrasClave obj);
        IEnumerable<t_incidenciaSolucionPalabrasClave> GetList();
        t_incidenciaSolucionPalabrasClave GetById(int id);
        List<t_incidenciaSolucionPalabrasClave> GetByIdIncSol(int id_incSol);
        bool InsertTags(tagsObjDTO tagsObjDto);
    }
}
