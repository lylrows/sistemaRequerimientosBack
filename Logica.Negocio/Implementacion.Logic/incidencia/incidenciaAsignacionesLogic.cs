using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciaAsignacionesLogic : IIncidenciaAsignacionesLogic
    {
        private IUnitOfWork _unitOfWork;

        public incidenciaAsignacionesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_incidenciaAsignaciones GetById(int id)
        {
            return _unitOfWork.IIncidenciaAsignaciones.GetById(id);
        }

        public IEnumerable<nivelSoporteDTO> getNivelSoporteById(in int id)
        {
            return _unitOfWork.IIncidenciaAsignaciones.getNivelSoporteById(id);
        }

        public personas getUsuarioASignado(in int objIdIncidencia)
        {
            return _unitOfWork.IIncidenciaAsignaciones.getUsuarioASignado(objIdIncidencia);
        }

        public personas getUsuarioRegistro(in int objIdIncidencia)
        {
            return _unitOfWork.IIncidenciaAsignaciones.getUsuarioRegistro(objIdIncidencia);
        }

        public incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int objIdIncidencia)
        {
            return _unitOfWork.IIncidenciaAsignaciones.getIncidenciaDetaliByEmail(objIdIncidencia);
        }

        public IEnumerable<t_incidenciaAsignaciones> GetList()
        {
            return _unitOfWork.IIncidenciaAsignaciones.GetList();
        }

        public int Insert(t_incidenciaAsignaciones obj)
        {
            _unitOfWork.IIncidenciaAsignaciones.borrarAsignaciones(obj.idIncidencia);
            return _unitOfWork.IIncidenciaAsignaciones.Insert(obj);
        }

        public bool Update(t_incidenciaAsignaciones obj)
        {
            return _unitOfWork.IIncidenciaAsignaciones.Update(obj);
        }

        public int getTicketsPendientes(int id)
        {
            return _unitOfWork.IIncidenciaAsignaciones.getTicketsPendientes(id);
        }
    }
}
