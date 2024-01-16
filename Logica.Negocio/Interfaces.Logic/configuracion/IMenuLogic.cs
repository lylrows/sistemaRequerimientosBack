using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IMenuLogic
    {
        bool Update(t_menu obj);
        int Insert(t_menu obj);
        IEnumerable<t_menu> GetList();
        t_menu GetById(int id);
        bool Delete(t_menu obj);
        getByIdRoleDTO GetByIdRole(int id);
    }
}
