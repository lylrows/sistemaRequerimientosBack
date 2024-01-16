using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.persona
{
    public interface IEmpresaANSRepository : IRepository<t_empresaANS>
    {
        IEnumerable<t_empresaANS> getANSByIdEmpresa(in int id);
        IEnumerable<incidenciaHorariosDTO> getIncidenciaHorarios();
        DateTime CalcularFechaMaximaDeAtencion(incidenciaHorariosDTO dto,  DateTime fechaHoraInicio,
             DateTime fechaHoraFin, DateTime fechaIngresoMaximo);
        bool updateFechaTiempoMaximoAtencion(in DateTime fechaTiempoMaximoAtencion, int dtoId);
        incidenciaHorariosDTO getIncidenciaHorarioById(in int id);
        bool cambioAnsDescartado(in int id);
    }
}
