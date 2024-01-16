using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.empresas;
using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.empresas
{
    public class tipoIncidenciasEmpresaLogic : ITipoincidenciasempresaLogic
    {
        private IUnitOfWork _unitOfWork;

        public tipoIncidenciasEmpresaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tipoIncidenciasEmpresa GetById(int id)
        {
            return _unitOfWork.ITipoincidenciasempresa.GetById(id);
        }
        
        public IEnumerable<tipoIncidenciasEmpresa> GetList()
        {
            return _unitOfWork.ITipoincidenciasempresa.GetList();
        }

        public int Insert(tipoIncidenciasEmpresa obj)
        {
            return _unitOfWork.ITipoincidenciasempresa.Insert(obj);
        }

        public bool Update(tipoIncidenciasEmpresa obj)
        {
            return _unitOfWork.ITipoincidenciasempresa.Update(obj);
        }

        public bool Delete(tipoIncidenciasEmpresa obj)
        {
            return _unitOfWork.ITipoincidenciasempresa.Delete(obj);
        }

    }
}