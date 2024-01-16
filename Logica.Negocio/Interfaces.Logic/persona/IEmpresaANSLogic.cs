using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.persona
{
    public interface IEmpresaANSLogic
    {
        bool Update(t_empresaANS obj);
        int Insert(t_empresaANS obj);
        IEnumerable<t_empresaANS> GetList();
        t_empresaANS GetById(int id);
        IEnumerable<t_empresaANS> getANSByIdEmpresa(in int id);
        IEnumerable<incidenciaHorariosDTO> getIncidenciaHorarios();
        bool getIncidenciaHorarioById(int id);
        bool cambioAnsDescartado(in int id);
    }
}
