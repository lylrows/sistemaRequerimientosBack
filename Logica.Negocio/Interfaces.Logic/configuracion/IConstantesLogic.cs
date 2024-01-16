using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IConstantesLogic
    {
        bool Update(t_constantes obj);
        int Insert(t_constantes obj);
        IEnumerable<t_constantes> GetList();
        t_constantes GetById(int id);
    }
}
