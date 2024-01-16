using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface IEmpresaSistemaUsuariosLogic
    {
        bool Update(t_empresaSistemaUsuarios obj);
        int Insert(t_empresaSistemaUsuarios obj);
        IEnumerable<t_empresaSistemaUsuarios> GetList();
        t_empresaSistemaUsuarios GetById(int id);
    }
}
