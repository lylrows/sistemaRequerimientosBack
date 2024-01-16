using System;
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.persona
{
    public class empresaANSLogic : IEmpresaANSLogic
    {
        private IUnitOfWork _unitOfWork;

        public empresaANSLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_empresaANS GetById(int id)
        {
            return _unitOfWork.IEmpresaANS.GetById(id);
        }

        public IEnumerable<t_empresaANS> getANSByIdEmpresa(in int id)
        {
            return _unitOfWork.IEmpresaANS.getANSByIdEmpresa(id);
        }

        public IEnumerable<incidenciaHorariosDTO> getIncidenciaHorarios()
        {
            List<incidenciaHorariosDTO> incidenciaHorarios = new List<incidenciaHorariosDTO>();
            incidenciaHorarios = (List<incidenciaHorariosDTO>) _unitOfWork.IEmpresaANS.getIncidenciaHorarios();
            DateTime fechaHoraInicio;
            DateTime fechaHoraFin;
            DateTime fechaIngresoMaximo;
            DateTime fechaTiempoMaximoAtencion;
            foreach (var Dto in incidenciaHorarios)
            {
                fechaHoraInicio = Dto.fechaRegistro.Date + Dto.horaInicio;
                fechaHoraFin = Dto.fechaRegistro.Date + Dto.horaFin;
                fechaIngresoMaximo = Dto.fechaRegistro.Date + Dto.ingresoMaximo;
                fechaTiempoMaximoAtencion = _unitOfWork.IEmpresaANS.CalcularFechaMaximaDeAtencion(Dto, fechaHoraInicio, fechaHoraFin, fechaIngresoMaximo);
                _unitOfWork.IEmpresaANS.updateFechaTiempoMaximoAtencion(fechaTiempoMaximoAtencion, Dto.id);
            }

            return incidenciaHorarios;
        }

        public bool getIncidenciaHorarioById(int id)
        {
            incidenciaHorariosDTO Dto = new incidenciaHorariosDTO();
            Dto = _unitOfWork.IEmpresaANS.getIncidenciaHorarioById(id);
            DateTime fechaHoraInicio = Dto.fechaRegistro.Date + Dto.horaInicio;
            DateTime fechaHoraFin = Dto.fechaRegistro.Date + Dto.horaFin;
            DateTime fechaIngresoMaximo = Dto.fechaRegistro.Date + Dto.ingresoMaximo;
            DateTime fechaTiempoMaximoAtencion = _unitOfWork.IEmpresaANS.CalcularFechaMaximaDeAtencion(Dto, fechaHoraInicio, fechaHoraFin, fechaIngresoMaximo);
            return _unitOfWork.IEmpresaANS.updateFechaTiempoMaximoAtencion(fechaTiempoMaximoAtencion, Dto.id);
        }

        public bool cambioAnsDescartado(in int id)
        {
            return _unitOfWork.IEmpresaANS.cambioAnsDescartado(id);
        }

        public IEnumerable<t_empresaANS> GetList()
        {
            return _unitOfWork.IEmpresaANS.GetList();
        }

        public int Insert(t_empresaANS obj)
        {
            return _unitOfWork.IEmpresaANS.Insert(obj);
        }

        public bool Update(t_empresaANS obj)
        {
            return _unitOfWork.IEmpresaANS.Update(obj);
        }
    }
}
