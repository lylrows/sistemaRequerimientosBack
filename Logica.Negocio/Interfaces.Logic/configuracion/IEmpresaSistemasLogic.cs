using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IEmpresaSistemasLogic
    {
        bool Update(t_empresaSistemas obj);
        int Insert(t_empresaSistemas obj);
        IEnumerable<t_empresaSistemas> GetList();
        t_empresaSistemas GetById(int id);
        IEnumerable<sistemasEmpresaDTO> getSistemasByIdEmpresa(in int id);
        IEnumerable<sistemasByIdUsuarioDTO> getSistemasByIdUsuario(in int id);
        IEnumerable<sistemasPorAsignarUsuarioDTO> getSistemasPorAsignarByIdUsuario(in int id);
        bool validaUsuarioAsociado(in int idSistema, in int idEmpresa);
        bool deleteEmpresaSistemas(in int idEmpresa, in int idSistema);
        IEnumerable<sistemasEmpresaByUser> getSistemasEmpresaByUser(in int id);
    }
}
