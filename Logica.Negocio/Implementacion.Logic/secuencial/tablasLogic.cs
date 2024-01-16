using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.secuencial;
using Modelos.Datos.Mapeo.Base.Datos.secuencial;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.secuencial
{
    public class tablasLogic : ITablasLogic
    {
        private IUnitOfWork _unitOfWork;

        public tablasLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tablas GetById(int id)
        {
            return _unitOfWork.ITablas.GetById(id);
        }
        public IEnumerable<tablas> GetList()
        {
            return _unitOfWork.ITablas.GetList();
        }

        public int Insert(tablas obj)
        {
            return _unitOfWork.ITablas.Insert(obj);
        }

        public bool Update(tablas obj)
        {
            return _unitOfWork.ITablas.Update(obj);
        }

        public bool Delete(tablas obj)
        {
            return _unitOfWork.ITablas.Delete(obj);
        }

    }
}