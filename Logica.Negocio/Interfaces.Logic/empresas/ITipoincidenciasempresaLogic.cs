using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.empresas;

namespace Logica.Negocio.Interfaces.Logic.empresas
{
    public interface ITipoincidenciasempresaLogic
    {
        bool Update(tipoIncidenciasEmpresa obj);
        int Insert(tipoIncidenciasEmpresa obj);
        IEnumerable<tipoIncidenciasEmpresa> GetList();
        tipoIncidenciasEmpresa GetById(int id);
        bool Delete(tipoIncidenciasEmpresa obj);
    }
}