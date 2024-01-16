using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;

namespace Logica.Negocio.Interfaces.Logic.configuracion
{
    public interface ISistemasLogic
    {
        bool Update(t_sistemas obj);
        int Insert(t_sistemas obj);
        IEnumerable<sistemasDTO> GetList();
        t_sistemas GetById(int id);
        int insertEmpresaSistemas(empresaSistemaRequestDTO empresaSistemaRequestDto);
        int validaSistema(in int id);
        IEnumerable<noAsignadosDTO> getSistemasNoAsociados(in int id);
    }
}
