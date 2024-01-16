using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class prioridadHistorialLogic : IPrioridadhistorialLogic
    {
        private IUnitOfWork _unitOfWork;

        public prioridadHistorialLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public prioridadHistorial GetById(int id)
        {
            return _unitOfWork.IPrioridadhistorial.GetById(id);
        }

       

        public IEnumerable<prioridadHistorial> GetList()
        {
            return _unitOfWork.IPrioridadhistorial.GetList();
        }

        public int Insert(prioridadHistorial obj)
        {
            return _unitOfWork.IPrioridadhistorial.Insert(obj);
        }

        public bool Update(prioridadHistorial obj)
        {
            return _unitOfWork.IPrioridadhistorial.Update(obj);
        }

        public bool Delete(prioridadHistorial obj)
        {
            return _unitOfWork.IPrioridadhistorial.Delete(obj);
        }

    }
}