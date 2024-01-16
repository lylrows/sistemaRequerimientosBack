using System;
using System.Collections.Generic;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.persona
{
    public class empresaHorariosLogic : IEmpresaHorariosLogic
    {
        private IUnitOfWork _unitOfWork;

        public empresaHorariosLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public t_empresaHorarios GetById(int id)
        {
            return _unitOfWork.IEmpresaHorarios.GetById(id);
        }

        public horarioEmpresaListDTO getHorarioEmpresaList(in int id)
        {
            return _unitOfWork.IEmpresaHorarios.getHorarioEmpresaList(id);
        }

        public IEnumerable<t_empresaHorarios> GetList()
        {
            return _unitOfWork.IEmpresaHorarios.GetList();
        }

        public int Insert(t_empresaHorarios obj)
        {
            DateTime now = GetLimaDateTimeNow();
            obj.fechaInicio = new DateTime(now.Year, now.Month, now.Day, obj.fechaInicio.Hour, obj.fechaInicio.Minute,obj.fechaInicio.Second);
            DateTime fechaAux = obj.fechaInicio;
            DateTime fecha = new DateTime(fechaAux.Year, fechaAux.Month, fechaAux.Day, 0, 0, 00);
            TimeSpan _horaInicio = new TimeSpan((obj.fechaInicio.Subtract(fecha)).Ticks);
            obj.horaInicio = _horaInicio;
            obj.fechaFin = new DateTime(now.Year, now.Month, now.Day, obj.fechaFin.Hour, obj.fechaFin.Minute, obj.fechaFin.Second);
            fechaAux = obj.fechaFin;
            fecha = new DateTime(fechaAux.Year, fechaAux.Month, fechaAux.Day, 0, 0, 00);
            TimeSpan _horaFin = new TimeSpan((obj.fechaFin.Subtract(fecha)).Ticks);
            obj.horaFin = _horaFin;
            return _unitOfWork.IEmpresaHorarios.Insert(obj);
        }

        public bool Update(t_empresaHorarios obj)
        {
            DateTime fechaAux = obj.fechaInicio;
            DateTime fecha = new DateTime(fechaAux.Year, fechaAux.Month, fechaAux.Day, 0, 0, 00);
            TimeSpan _horaInicio = new TimeSpan((obj.fechaInicio.Subtract(fecha)).Ticks);
            obj.horaInicio = _horaInicio;
            fechaAux = obj.fechaFin;
            fecha = new DateTime(fechaAux.Year, fechaAux.Month, fechaAux.Day, 0, 0, 00);
            TimeSpan _horaFin = new TimeSpan((obj.fechaFin.Subtract(fecha)).Ticks);
            obj.horaFin = _horaFin;
            return _unitOfWork.IEmpresaHorarios.Update(obj);
        }

        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }
    }
}
