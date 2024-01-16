using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using Modelos.Datos.Respuesta.DTO;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciaComentariosLogic
    {
        bool Update(t_incidenciaComentarios obj);
        int Insert(t_incidenciaComentarios obj);
        IEnumerable<t_incidenciaComentarios> GetList();
        t_incidenciaComentarios GetById(int id);
        IEnumerable<comentariosByIdincidenciaDTO> getComentariosByIdincidencia(in int id);
    }
}
