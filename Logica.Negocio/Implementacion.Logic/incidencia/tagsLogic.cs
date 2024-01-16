using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class tagsLogic : ITagsLogic
    {
        private IUnitOfWork _unitOfWork;

        public tagsLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tags GetById(int id)
        {
            return _unitOfWork.ITags.GetById(id);
        }

        public IEnumerable<tags> GetList()
        {
            return _unitOfWork.ITags.GetList();
        }

        public int Insert(tags obj)
        {
            return _unitOfWork.ITags.Insert(obj);
        }

        public bool Update(tags obj)
        {
            return _unitOfWork.ITags.Update(obj);
        }

        public bool Delete(tags obj)
        {
            return _unitOfWork.ITags.Delete(obj);
        }
    }
}
