using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using System;
using System.Collections.Generic;
using System.Text;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class muralLogic : IMuralLogic
    {
        private IUnitOfWork _unitOfWork;

        public muralLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public mural GetById(int id)
        {
            return _unitOfWork.IMural.GetById(id);
        }

        public IEnumerable<mural> GetList()
        {
            return _unitOfWork.IMural.GetList();
        }

        public int Insert(mural obj)
        {
            return _unitOfWork.IMural.Insert(obj);
        }

        public bool Update(mural obj)
        {
            return _unitOfWork.IMural.Update(obj);
        }

        public bool Delete(mural obj)
        {
            return _unitOfWork.IMural.Delete(obj);
        }

    }
}
