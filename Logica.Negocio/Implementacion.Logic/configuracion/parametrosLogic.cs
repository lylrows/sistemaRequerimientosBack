
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Unidad.Trabajo;


namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class parametrosLogic : IParametrosLogic
    {
        private IUnitOfWork _unitOfWork;

        public parametrosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_parametros GetById(int id)
        {
            return _unitOfWork.IParametros.GetById(id);
        }

        public IEnumerable<t_parametros> GetList()
        {
            return _unitOfWork.IParametros.GetList();
        }

        public int Insert(t_parametros obj)
        {
            return _unitOfWork.IParametros.Insert(obj);
        }

        public bool Update(t_parametros obj)
        {
            return _unitOfWork.IParametros.Update(obj);
        }

    }
}
