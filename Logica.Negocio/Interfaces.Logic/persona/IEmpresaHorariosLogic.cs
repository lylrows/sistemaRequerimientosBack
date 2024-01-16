using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.persona
{
    public interface IEmpresaHorariosLogic
    {
        bool Update(t_empresaHorarios obj);
        int Insert(t_empresaHorarios obj);
        IEnumerable<t_empresaHorarios> GetList();
        t_empresaHorarios GetById(int id);
        horarioEmpresaListDTO getHorarioEmpresaList(in int id);
    }
}
