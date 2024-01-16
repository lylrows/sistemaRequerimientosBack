using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.persona
{
    public class empresasLogic : IEmpresasLogic
    {
        private IUnitOfWork _unitOfWork;

        public empresasLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_empresa GetById(int id)
        {
            return _unitOfWork.IEmpresas.GetById(id);
        }

        public IEnumerable<t_empresa> getEmpresaByIdUsuario(in int id)
        {
            return _unitOfWork.IEmpresas.getEmpresaByIdUsuario(id);
        }

        public IEnumerable<t_empresa> GetList()
        {
            return _unitOfWork.IEmpresas.GetList();
        }

        public int Insert(t_empresa obj)
        {
            return _unitOfWork.IEmpresas.Insert(obj);
        }

        public bool Update(t_empresa obj)
        {
            return _unitOfWork.IEmpresas.Update(obj);
        }
    }
}
