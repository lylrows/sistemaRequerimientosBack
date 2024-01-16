using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.configuracion
{
    public class empresaSistemasLogic : IEmpresaSistemasLogic
    {
        private IUnitOfWork _unitOfWork;

        public empresaSistemasLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_empresaSistemas GetById(int id)
        {
            return _unitOfWork.IEmpresaSistemas.GetById(id);
        }

        public IEnumerable<sistemasEmpresaDTO> getSistemasByIdEmpresa(in int id)
        {
            return _unitOfWork.IEmpresaSistemas.getSistemasByIdEmpresa(id);
        }

        public IEnumerable<sistemasByIdUsuarioDTO> getSistemasByIdUsuario(in int id)
        {
            return _unitOfWork.IEmpresaSistemas.getSistemasByIdUsuario(id);
        }

        public IEnumerable<sistemasPorAsignarUsuarioDTO> getSistemasPorAsignarByIdUsuario(in int id)
        {
            return _unitOfWork.IEmpresaSistemas.getSistemasPorAsignarByIdUsuario(id);
        }

        public bool validaUsuarioAsociado(in int idSistema, in int idEmpresa)
        {
            return _unitOfWork.IEmpresaSistemas.validaUsuarioAsociado(idSistema, idEmpresa);
        }

        public bool deleteEmpresaSistemas(in int idEmpresa, in int idSistema)
        {
            return _unitOfWork.IEmpresaSistemas.deleteEmpresaSistemas(idEmpresa, idSistema);
        }

        public IEnumerable<sistemasEmpresaByUser> getSistemasEmpresaByUser(in int id)
        {
            return _unitOfWork.IEmpresaSistemas.getSistemasEmpresaByUser(id);
        }

        public IEnumerable<t_empresaSistemas> GetList()
        {
            return _unitOfWork.IEmpresaSistemas.GetList();
        }

        public int Insert(t_empresaSistemas obj)
        {
            return _unitOfWork.IEmpresaSistemas.Insert(obj);
        }

        public bool Update(t_empresaSistemas obj)
        {
            return _unitOfWork.IEmpresaSistemas.Update(obj);
        }
    }
}
