using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.mejora
{
    public class mejoraArchivosLogic : IMejoraArchivosLogic
    {
        private IUnitOfWork _unitOfWork;

        public mejoraArchivosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_mejoraArchivos GetById(int id)
        {
            return _unitOfWork.IMejoraArchivos.GetById(id);
        }

        public IEnumerable<t_mejoraArchivos> GetList()
        {
            return _unitOfWork.IMejoraArchivos.GetList();
        }

        public int Insert(t_mejoraArchivos obj)
        {
            return _unitOfWork.IMejoraArchivos.Insert(obj);
        }

        public bool Update(t_mejoraArchivos obj)
        {
            return _unitOfWork.IMejoraArchivos.Update(obj);
        }

        public bool Delete(t_mejoraArchivos obj)
        {
            return _unitOfWork.IMejoraArchivos.Delete(obj);
        }

    }
}
