using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciaComentariosLogic : IIncidenciaComentariosLogic
    {
        private IUnitOfWork _unitOfWork;

        public incidenciaComentariosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_incidenciaComentarios GetById(int id)
        {
            return _unitOfWork.IIncidenciaComentarios.GetById(id);
        }

        public IEnumerable<comentariosByIdincidenciaDTO> getComentariosByIdincidencia(in int id)
        {
            return _unitOfWork.IIncidenciaComentarios.getComentariosByIdincidencia(id);
        }

        public IEnumerable<t_incidenciaComentarios> GetList()
        {
            return _unitOfWork.IIncidenciaComentarios.GetList();
        }

        public int Insert(t_incidenciaComentarios obj)
        {
            return _unitOfWork.IIncidenciaComentarios.Insert(obj);
        }

        public bool Update(t_incidenciaComentarios obj)
        {
            return _unitOfWork.IIncidenciaComentarios.Update(obj);
        }
    }
}
