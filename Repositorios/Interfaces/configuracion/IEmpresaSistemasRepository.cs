using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;


namespace Repositorios.Interfaces.configuracion
{
    public interface IEmpresaSistemasRepository:IRepository<t_empresaSistemas>
    {
        IEnumerable<sistemasEmpresaDTO> getSistemasByIdEmpresa(in int id);
        IEnumerable<sistemasByIdUsuarioDTO> getSistemasByIdUsuario(in int id);
        IEnumerable<sistemasPorAsignarUsuarioDTO> getSistemasPorAsignarByIdUsuario(in int id);
        bool validaUsuarioAsociado(in int idSistema, in int idEmpresa);
        bool deleteEmpresaSistemas(in int idEmpresa, in int idSistema);
        IEnumerable<sistemasEmpresaByUser> getSistemasEmpresaByUser(in int id);
    }
}
