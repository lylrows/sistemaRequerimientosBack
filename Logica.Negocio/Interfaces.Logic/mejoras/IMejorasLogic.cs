using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.mejora;
using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Solicitud.DTO;

namespace Logica.Negocio.Interfaces.Logic.mejoras
{
    public interface IMejorasLogic
    {
        bool Update(t_mejoras obj);
        int Insert(t_mejoras obj);
        IEnumerable<t_mejoras> GetList();
        t_mejoras GetById(int id);
        bool Delete(t_mejoras obj);
        IEnumerable<usuariosAsignar> obtenerUsuariosParaAsignarByMejora(in int id);
        List<mejoraGridListDTO> obtenerMejoraPorIdUsuario(filterDataDTO obj);
        List<mejoraComplete> obtenerMejoraPorIdClienteEmpresa(int idUsuario);
        mejoraDTO getMejoraById(int id);
        List<ticketsAsosciadosDTO> getTicketsAsosciados(ticketsAsosciadosFilter ticketsAsosciadosFilter);
    }
}
