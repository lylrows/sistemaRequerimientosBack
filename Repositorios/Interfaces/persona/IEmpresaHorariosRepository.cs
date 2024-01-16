using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Repositorios.Interfaces.persona
{
    public interface IEmpresaHorariosRepository : IRepository<t_empresaHorarios>
    {
        horarioEmpresaListDTO getHorarioEmpresaList(in int id);
    }
}
