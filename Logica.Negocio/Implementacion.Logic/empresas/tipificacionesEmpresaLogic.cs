using System;
using System.Collections.Generic;
using System.Text;
using Logica.Negocio.Interfaces.Logic.empresas;
using Modelos.Datos.Mapeo.Base.Datos.empresas;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.empresas
{
    public class tipificacionesEmpresaLogic : ITipificacionesempresaLogic
    {
        private IUnitOfWork _unitOfWork;

        public tipificacionesEmpresaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public tipificacionesEmpresa GetById(int id)
        {
            return _unitOfWork.ITipificacionesempresa.GetById(id);
        }

        public IEnumerable<tipificacionesEmpresa> GetList()
        {
            return _unitOfWork.ITipificacionesempresa.GetList();
        }

        public int Insert(tipificacionesEmpresa obj)
        {
            return _unitOfWork.ITipificacionesempresa.Insert(obj);
        }

        public bool Update(tipificacionesEmpresa obj)
        {
            return _unitOfWork.ITipificacionesempresa.Update(obj);
        }

        public bool Delete(tipificacionesEmpresa obj)
        {
            return _unitOfWork.ITipificacionesempresa.Delete(obj);
        }

        public tipificacionByEmpresaDTO getTipificacionByEmpresa(in int id)
        {
            return _unitOfWork.ITipificacionesempresa.getTipificacionByEmpresa(id);
        }

        public IEnumerable<empresasByGerenciaDTO> getEmpresasByGerencia()
        {
            return _unitOfWork.ITipificacionesempresa.getEmpresasByGerencia();
        }

        public IEnumerable<soporteByAsignacionDTO> getSoporteByAsignacion()
        {
            return _unitOfWork.ITipificacionesempresa.getSoporteByAsignacion();
        }
    }
}
