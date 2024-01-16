using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciaAsignacionesLogic
    {
        bool Update(t_incidenciaAsignaciones obj);
        int Insert(t_incidenciaAsignaciones obj);
        IEnumerable<t_incidenciaAsignaciones> GetList();
        t_incidenciaAsignaciones GetById(int id);
        IEnumerable<nivelSoporteDTO> getNivelSoporteById(in int id);
        personas getUsuarioASignado(in int objIdIncidencia);
        personas getUsuarioRegistro(in int objIdIncidencia);
        incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int objIdIncidencia);
        int getTicketsPendientes(int id);
    }
}
