using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.persona
{
    public interface IT_personasRepository : IRepository<personas>
    {
        getNombresDTO GetNombres(in int id);
        int InsertUser(personas obj, string contrasenia);
        IEnumerable<personas> getUsuariosByEmpresa(in int id);
        IEnumerable<usuariosByEmpresaDTO> getUsersByIdEmpresa(in int id);
    }
}
