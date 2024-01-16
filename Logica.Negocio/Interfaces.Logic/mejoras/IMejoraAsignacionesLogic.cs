using Modelos.Datos.Mapeo.Base.Datos.mejora;
using System.Collections.Generic;

namespace Logica.Negocio.Interfaces.Logic.mejoras
{
    public interface IMejoraAsignacionesLogic
    {
        bool Update(t_mejoraAsignaciones obj);
        int Insert(t_mejoraAsignaciones obj);
        IEnumerable<t_mejoraAsignaciones> GetList();
        t_mejoraAsignaciones GetById(int id);
        bool Delete(t_mejoraAsignaciones obj);
    }
}
