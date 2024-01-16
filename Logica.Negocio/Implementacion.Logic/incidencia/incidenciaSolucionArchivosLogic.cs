using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Unidad.Trabajo;


namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciaSolucionArchivosLogic:IIncidenciaSolucionArchivosLogic
    {
        private IUnitOfWork _unitOfWork;

        public incidenciaSolucionArchivosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_incidenciaSolucionArchivos GetById(int id)
        {
            return _unitOfWork.IIncidenciaSolucionArchivos.GetById(id);
        }

        public List<t_incidenciaSolucionArchivos> GetByIdIncSol(int id)
        {
            return _unitOfWork.IIncidenciaSolucionArchivos.GetByIdIncSol(id);
        }

        public IEnumerable<t_incidenciaSolucionArchivos> GetList()
        {
            return _unitOfWork.IIncidenciaSolucionArchivos.GetList();
        }

        public int Insert(t_incidenciaSolucionArchivos obj)
        {
            return _unitOfWork.IIncidenciaSolucionArchivos.Insert(obj);
        }

        public bool Update(t_incidenciaSolucionArchivos obj)
        {
            return _unitOfWork.IIncidenciaSolucionArchivos.Update(obj);
        }
    }
}
