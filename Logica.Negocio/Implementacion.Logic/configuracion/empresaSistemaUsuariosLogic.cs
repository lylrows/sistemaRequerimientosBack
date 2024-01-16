using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Unidad.Trabajo;


namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class empresaSistemaUsuariosLogic : IEmpresaSistemaUsuariosLogic
    {
        private IUnitOfWork _unitOfWork;

        public empresaSistemaUsuariosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_empresaSistemaUsuarios GetById(int id)
        {
            return _unitOfWork.IEmpresaSistemaUsuarios.GetById(id);
        }

        public IEnumerable<t_empresaSistemaUsuarios> GetList()
        {
            return _unitOfWork.IEmpresaSistemaUsuarios.GetList();
        }

        public int Insert(t_empresaSistemaUsuarios obj)
        {
            return _unitOfWork.IEmpresaSistemaUsuarios.Insert(obj);
        }

        public bool Update(t_empresaSistemaUsuarios obj)
        {
            return _unitOfWork.IEmpresaSistemaUsuarios.Update(obj);
        }
    }
}
