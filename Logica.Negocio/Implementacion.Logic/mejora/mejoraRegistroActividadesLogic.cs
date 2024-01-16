using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using Unidad.Trabajo;


namespace Logica.Negocio.Implementacion.Logic.mejora
{
    public class mejoraRegistroActividadesLogic : IMejoraRegistroActividadesLogic
    {
        private IUnitOfWork _unitOfWork;

        public mejoraRegistroActividadesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_mejoraRegistroActividades GetById(int id)
        {
            return _unitOfWork.IRegistroActividades.GetById(id);
        }

        public IEnumerable<t_mejoraRegistroActividades> GetList()
        {
            return _unitOfWork.IRegistroActividades.GetList();
        }

        public int Insert(t_mejoraRegistroActividades obj)
        {
            return _unitOfWork.IRegistroActividades.Insert(obj);
        }

        public bool Update(t_mejoraRegistroActividades obj)
        {
            return _unitOfWork.IRegistroActividades.Update(obj);
        }

        public bool Delete(t_mejoraRegistroActividades obj)
        {
            return _unitOfWork.IRegistroActividades.Delete(obj);
        }
    }
}
