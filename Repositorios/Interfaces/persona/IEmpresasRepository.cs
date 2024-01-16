using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.persona
{
    public interface IEmpresasRepository : IRepository<t_empresa>
    {
        IEnumerable<t_empresa> getEmpresaByIdUsuario(in int id);
    }
}
