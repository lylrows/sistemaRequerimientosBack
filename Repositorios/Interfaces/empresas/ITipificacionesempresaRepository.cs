using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.empresas
{
    public interface ITipificacionesempresaRepository : IRepository<tipificacionesEmpresa>
    {
        tipificacionByEmpresaDTO getTipificacionByEmpresa(in int id);
        IEnumerable<empresasByGerenciaDTO> getEmpresasByGerencia();
        IEnumerable<soporteByAsignacionDTO> getSoporteByAsignacion();
    }
}
