using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.mejora;
using System;
using System.Collections.Generic;
using System.Text;
using Modelos.Datos.Solicitud.DTO;

namespace Repositorios.Interfaces.mejoras
{
    public interface IMejorasRepository : IRepository<t_mejoras>
    {
        List<usuariosAsignar> obtenerUsuariosParaAsignarByMejora(in int idMejora);
        List<mejoraGridListDTO> obtenerMejoraPorIdUsuario(filterDataDTO obj);
        List<mejoraComplete> obtenerMejoraPorIdClienteEmpresa(int idUsuario);

        List<ticketsAsosciadosDTO> getTicketsAsosciados(ticketsAsosciadosFilter ticketsAsosciadosFilter);
        List<string> getManagerEmailsById(int idEmpresa, int v);
        approverUserData getApproverUserDataById(int id);
        List<string> getBpoEmailsById(int v, int? idUsuarioRegistro);
    }

}
