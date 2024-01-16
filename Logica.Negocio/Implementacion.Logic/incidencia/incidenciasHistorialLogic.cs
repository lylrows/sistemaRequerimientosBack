using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciasHistorialLogic : IIncidenciashistorialLogic
    {
        private IUnitOfWork _unitOfWork;

        public incidenciasHistorialLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public incidenciasHistorial GetById(int id)
        {
            return _unitOfWork.IIncidenciashistorial.GetById(id);
        }

        public IEnumerable<incidenciasHistorial> GetList()
        {
            return _unitOfWork.IIncidenciashistorial.GetList();
        }

        public int Insert(incidenciasHistorial obj)
        {
            return _unitOfWork.IIncidenciashistorial.Insert(obj);
        }

        public bool Update(incidenciasHistorial obj)
        {
            return _unitOfWork.IIncidenciashistorial.Update(obj);
        }

        public bool Delete(incidenciasHistorial obj)
        {
            return _unitOfWork.IIncidenciashistorial.Delete(obj);
        }
    }
}