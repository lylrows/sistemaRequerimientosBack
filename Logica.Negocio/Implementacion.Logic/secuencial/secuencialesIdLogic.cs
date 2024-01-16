using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.secuencial;
using Modelos.Datos.Mapeo.Base.Datos.secuencial;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.secuencial
{
    public class secuencialesIdLogic : ISecuencialesidLogic
    {
        private IUnitOfWork _unitOfWork;

        public secuencialesIdLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public secuencialesId GetById(int id)
        {
            return _unitOfWork.ISecuencialesid.GetById(id);
        }
        
        public IEnumerable<secuencialesId> GetList()
        {
            return _unitOfWork.ISecuencialesid.GetList();
        }

        public int Insert(secuencialesId obj)
        {
            return _unitOfWork.ISecuencialesid.Insert(obj);
        }

        public bool Update(secuencialesId obj)
        {
            return _unitOfWork.ISecuencialesid.Update(obj);
        }

        public bool Delete(secuencialesId obj)
        {
            return _unitOfWork.ISecuencialesid.Delete(obj);
        }
    }
}