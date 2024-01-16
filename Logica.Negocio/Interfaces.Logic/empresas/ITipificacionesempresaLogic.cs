using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.empresas
{
    public interface ITipificacionesempresaLogic
    {
        bool Update(tipificacionesEmpresa obj);
        int Insert(tipificacionesEmpresa obj);
        IEnumerable<tipificacionesEmpresa> GetList();
        tipificacionesEmpresa GetById(int id);
        bool Delete(tipificacionesEmpresa obj);
        tipificacionByEmpresaDTO getTipificacionByEmpresa(in int id);
        IEnumerable<empresasByGerenciaDTO> getEmpresasByGerencia();
        IEnumerable<soporteByAsignacionDTO> getSoporteByAsignacion();
    }
}