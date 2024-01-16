using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class parametroDetallesLogic : IParametroDetalles
    {
        private IUnitOfWork _unitOfWork;

        public parametroDetallesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_parametroDetalles GetById(int id)
        {
            return _unitOfWork.IParametroDetalles.GetById(id);
        }

        public IEnumerable<t_parametroDetalles> GetList()
        {
            return _unitOfWork.IParametroDetalles.GetList();
        }

        public int Insert(t_parametroDetalles obj)
        {
            return _unitOfWork.IParametroDetalles.Insert(obj);
        }

        public bool Update(t_parametroDetalles obj)
        {
            return _unitOfWork.IParametroDetalles.Update(obj);
        }
    }
}
