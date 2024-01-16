using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;


namespace Repositorios.Interfaces.configuracion
{
    public interface IMenuRepository : IRepository<t_menu>
    {
        getByIdRoleDTO GetByIdRole(int id);
    }
}
