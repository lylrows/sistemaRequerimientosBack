using System;
using System.Collections.Generic;
using System.Linq;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Logica.Negocio.Interfaces.Logic.persona;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Modelos.Datos.Solicitud.DTO.incidencia;
using Unidad.Trabajo;

namespace Logica.Negocio.Implementacion.Logic.incidencia
{
    public class incidenciasLogic : IIncidenciasLogic
    {
        private IUnitOfWork _unitOfWork;
        private IIncidenciaArchivosLogic _incidenciaArchivosLogic;
        private IIncidenciaComentariosLogic _incidenciaComentariosLogic;
        private IIncidenciaAsignacionesLogic _incidenciaAsignacionesLogic;
        IEmpresaANSLogic _ans;

        public incidenciasLogic(IUnitOfWork unitOfWork, IIncidenciaComentariosLogic incidenciaComentariosLogic, 
            IIncidenciaArchivosLogic incidenciaArchivosLogic, IIncidenciaAsignacionesLogic incidenciaAsignacionesLogic, IEmpresaANSLogic ans)
        {
            _unitOfWork = unitOfWork;
            _incidenciaArchivosLogic = incidenciaArchivosLogic;
            _incidenciaComentariosLogic = incidenciaComentariosLogic;
            _incidenciaAsignacionesLogic = incidenciaAsignacionesLogic;
            _ans = ans;
        }

        public t_incidencias GetById(int id)
        {
            return _unitOfWork.IIncidencias.GetById(id);
        }

        public int Insert(t_incidencias obj)
        {
            List<usuariosAsignar> usuarios = new List<usuariosAsignar>();
            int idIncidencia = 0;
            obj.idTicket = _unitOfWork.IIncidencias.getIdSecuencialTicket(obj.idEmpSist, 1);
            idIncidencia = _unitOfWork.IIncidencias.Insert(obj);
            _ans.getIncidenciaHorarioById(idIncidencia);
            usuarios = _unitOfWork.IIncidencias.obtenerUsuariosParaAsignar(idIncidencia);
            if (usuarios.Any())
            {
                usuariosAsignar escalar = new usuariosAsignar();
                t_incidenciaAsignaciones asignar = new t_incidenciaAsignaciones();
                escalar = usuarios.FindAll(x => x.idNivelSoporte == 2)[0];
                int idUsuarioEscalar;
                if (escalar == null)
                {
                    idUsuarioEscalar = 0;
                }
                else
                {
                    idUsuarioEscalar = escalar.idUsuario;
                }
                foreach (var usuariosAsignar in usuarios)
                {
                    if (usuariosAsignar.idNivelSoporte == 1)
                    {
                        asignar = new t_incidenciaAsignaciones();
                        asignar.idIncidencia = idIncidencia;
                        asignar.idUsuarioOrigen = obj.idUsuarioRegistro;
                        asignar.idUsuaroAsignado = usuariosAsignar.idUsuario;
                        asignar.idUsuarioEscalar = idUsuarioEscalar;
                        asignar.esActivo = 1;
                        _incidenciaAsignacionesLogic.Insert(asignar);
                    }
                   
                }
            }
            else
            {
                idIncidencia = -1;
            }
            //insertar historial
            incidenciasHistorial historial = new incidenciasHistorial();
            historial.idIncidencia = idIncidencia;
            historial.idUsuario = obj.idUsuarioRegistro;
            historial.idEstado = obj.idEstado;
            historial.fechaRegistro = GetLimaDateTimeNow();
            _unitOfWork.IIncidenciashistorial.Insert(historial);


            return obj.idTicket;
        }

        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }

        public IEnumerable<t_incidencias> GetList()
        {
            return _unitOfWork.IIncidencias.GetList();
        }

        public int Insert(GetIncidenciaArchivosComentarios obj)
        {
            try
            {
                obj.incidencia.idTicket = _unitOfWork.IIncidencias.getIdSecuencialTicket(obj.incidencia.idEmpSist, 1);
                int idIncidencia = _unitOfWork.IIncidencias.Insert(obj.incidencia);
                _ans.getIncidenciaHorarioById(idIncidencia);
                //asignar idIncidencia a comentarios y archivos
                for (int i=0;i<obj.lstArchivos.Count;i++)
                {
                    obj.lstArchivos[i].idIncidencia = idIncidencia;
                    _incidenciaArchivosLogic.Insert(obj.lstArchivos[i]);
                }
                for (int i = 0; i < obj.lstComentarios.Count; i++)
                {
                    obj.lstComentarios[i].idIncidencia = idIncidencia;
                    _incidenciaComentariosLogic.Insert(obj.lstComentarios[i]);
                }
                //insertar Historial
                incidenciasHistorial historial = new incidenciasHistorial();
                historial.idIncidencia = idIncidencia;
                historial.idUsuario = obj.incidencia.idUsuarioRegistro;
                historial.idEstado = obj.incidencia.idEstado;
                historial.fechaRegistro = GetLimaDateTimeNow();
                _unitOfWork.IIncidenciashistorial.Insert(historial);
                return obj.incidencia.idTicket;
            }
            catch(Exception e)
            {
                return 0;
            }

        }

        public bool Update(t_incidencias obj)
        {
            t_incidencias obj2 = _unitOfWork.IIncidencias.GetById(obj.id);
            if (obj.idEstado != obj2.idEstado)
            {
                //insertar historial solo si el estado cambia
                incidenciasHistorial historial = new incidenciasHistorial();
                historial.idIncidencia = obj.id;
                historial.idUsuario = obj.idUsuarioActualiza;
                historial.idEstado = obj.idEstado;  
                historial.fechaRegistro = GetLimaDateTimeNow();  
                _unitOfWork.IIncidenciashistorial.Insert(historial);
            }
            
            return _unitOfWork.IIncidencias.Update(obj);
        }
        public incidenciaArchivosComentarios_complete getIncidenciaArchivosComentariosxIncidencia(int id)
        {
            return _unitOfWork.IIncidencias.getIncidenciaArchivosComentariosxIncidencia(id);
        }

        public IEnumerable<usuariosAsignar> obtenerUsuariosParaAsignar(in int id)
        {
            return _unitOfWork.IIncidencias.obtenerUsuariosParaAsignar(id);
        }

        public IEnumerable<incidenciasGridDTO> getIncidenciasByRolAndUsuarioid(string rol, in int id, int idNivel)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByRolAndUsuarioid(rol, id, idNivel);
        }
        public List<incidenciaComentariosArchivos_getCompleteFilter> getIncidenciasArchivosComentariosFilter()
        {
            return _unitOfWork.IIncidencias.getIncidenciasArchivosComentariosFilter();
        }

        public bool updateincidenciaTipifica(t_incidencias obj)
        {
            t_incidencias obj2 = _unitOfWork.IIncidencias.GetById(obj.id);
            if (obj.idEstado != obj2.idEstado)
            {
                //insertar historial solo si el estado cambia
                incidenciasHistorial historial = new incidenciasHistorial();
                historial.idIncidencia = obj.id;
                historial.idUsuario = obj.idUsuarioActualiza;
                historial.idEstado = obj.idEstado;
                historial.fechaRegistro = GetLimaDateTimeNow();
                _unitOfWork.IIncidenciashistorial.Insert(historial);
            }
           
            return _unitOfWork.IIncidencias.updateincidenciaTipifica(obj);
        }
        public bool cumpleANS(int diasRespuesta, t_incidencias incidencia)
        {
            return _unitOfWork.IIncidencias.cumpleANS(diasRespuesta,incidencia);
        }
        public personas getUsuarioASignado(t_incidencias incidencia)
        {
            return _unitOfWork.IIncidencias.getUsuarioASignado(incidencia);
        }
            public personas getUsuarioRegistro(t_incidencias incidencia)
        {
            return _unitOfWork.IIncidencias.getUsuarioRegistro(incidencia);
        }
        public string getLinkIncidencia()
        {
            return _unitOfWork.IIncidencias.getLinkIncidencia();
        }
        public List<incidenciaByTipifFecha> getIncidenciasByTipifFecha(FilterIncidenciaByFechaById Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByTipifFecha(Entity);
        }
        public incidenciaByTipifListDecimal Incidencia_conteoHorasByIncidenciaSistema(FilterIncidenciaByMonthByEmp Entity)
        {
            return _unitOfWork.IIncidencias.Incidencia_conteoHorasByIncidenciaSistema(Entity);
        }
        public List<incidenciaBySistemaFecha> getIncidenciasBySistemaFecha(FilterIncidenciaByFechaById Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasBySistemaFecha(Entity);
        }
        public incidenciaByTipifList getIncidenciasByTipifList(FilterIncidenciaByTipifListByEmp Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByTipifList(Entity);
        }
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_sol(FilterIncidenciaByMonth Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByTipifFecha_sol(Entity);
        }
        public seriesAtencionSolicitudes getANSByMonth_sol(FilterIncidenciaANSByMonth Entity)
        {
            return _unitOfWork.IIncidencias.getANSByMonth_sol(Entity);
        }
        public incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int incidenciaId)
        {
            return _unitOfWork.IIncidencias.getIncidenciaDetaliByEmail(incidenciaId);
        }
        public List<object> obtenerIncidenciasSistemaPorIdUsuario(int idUsuario)
        {
            return _unitOfWork.IIncidencias.obtenerIncidenciasSistemaPorIdUsuario(idUsuario);
        }

        public IEnumerable<incidenciasGridDTO> getTicketsGerenteCliente(in int id)
        {
            return _unitOfWork.IIncidencias.getTicketsGerenteCliente(id);
        }

        public IEnumerable<incidenciasGridDTO> getTicketsGerenteSoporte(in int id)
        {
            return _unitOfWork.IIncidencias.getTicketsGerenteSoporte(id);
        }
        public incidenciaByTipifList getIncidenciasBySistemaFecha_sol(FilterIncidenciaByMonth Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasBySistemaFecha_sol(Entity);
        }
        public IncidenciasByEtapa getIncidenciasByEtapa(onlyIdAndRol Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByEtapa(Entity);
        }
        public IncidenciasByEtapa getIncidenciasByEtapaCliente(onlyIdAndRol Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByEtapaCliente(Entity);
        }
        public IncidenciasByEstado getIncidenciasByEstado(onlyIdAndRol Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByEstado(Entity);
        }
        public IncidenciasByEstado getIncidenciasByEstadoCliente(onlyIdAndRol Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByEstadoCliente(Entity);
        }
        public incidenciaByTipifList Incidencias_getEstadosByUsuario(onlyIdAndRol Entity)
        {
            return _unitOfWork.IIncidencias.Incidencias_getEstadosByUsuario(Entity);
        }
        public incidenciaByTipifList Incidencias_getEstadosByCliente(onlyIdAndRol Entity)
        {
            return _unitOfWork.IIncidencias.Incidencias_getEstadosByCliente(Entity);
        }
        public IncidenciasByEtapa getIncidenciasByEtapaGen()
        {
            return _unitOfWork.IIncidencias.getIncidenciasByEtapaGen();
        }
        public incidenciaByTipifList Incidencias_getEstadosByUsuarioGen()
        {
            return _unitOfWork.IIncidencias.Incidencias_getEstadosByUsuarioGen();
        }
        public IncidenciasByEstado getIncidenciasByEstadoGen()
        {
            return _unitOfWork.IIncidencias.getIncidenciasByEstadoGen();
        }
        public incidenciaByTipifList getIncidenciasBySistemaFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasBySistemaFecha_solByEmp(Entity);
        }
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity)
        {
            return _unitOfWork.IIncidencias.getIncidenciasByTipifFecha_solByEmp(Entity);
        }
        public List<IncidenciaHorasByMes> Incidencias_getHorasByMes(FilterIncidenciaByEmpMonth Entity)
        {
            return _unitOfWork.IIncidencias.Incidencias_getHorasByMes(Entity);
        }
        public List<IncidenciaHorasUsuarioAsignadoSistemaByMonth> Incidencia_getHorasUsuarioAsignadoSistemaByMonth(FilterIncidenciaByEmpMonth Entity)
        {
            return _unitOfWork.IIncidencias.Incidencia_getHorasUsuarioAsignadoSistemaByMonth(Entity);
        }
        public List<IncidenciasHorasSistemaByMonth> Incidencia_getHorasUsuarioAsignadoByMonth(FilterIncidenciaByEmpMonth Entity)
        {
            return _unitOfWork.IIncidencias.Incidencia_getHorasUsuarioAsignadoByMonth(Entity);
        }
        public List<IncidenciaHorasUsuarioAsignadoByMonth> Incidencias_getHorasSistemaByMonth(FilterIncidenciaByEmpMonth Entity)
        {
            return _unitOfWork.IIncidencias.Incidencias_getHorasSistemaByMonth(Entity);
        }

        public IEnumerable<reporteIncidenciaResponseDTO> getReporteIncidenciasByFechas(reporteIncidenciaDTO objDto)
        {
            return _unitOfWork.IIncidencias.getReporteIncidenciasByFechas(objDto);
        }
        public List<incidenciaFactorRendimientoAsignado> Incidencia_getFactorRendimientoAsignado(FIlterIncidenciaByAsigMonth Entity)
        {
            return _unitOfWork.IIncidencias.Incidencia_getFactorRendimientoAsignado(Entity);
        }
        public List<IncidenciaGetTable1> Incidencia_getTicketHorasTable1(FilterIncidenciaByMonthYearEmp Entity)
        {
            return _unitOfWork.IIncidencias.Incidencia_getTicketHorasTable1(Entity);
        }
        public List<incidencia_dataIntLabelString> Incidencia_getANSByEmp(FilterIncidenciaByEmpDate Entity)
        {
            return _unitOfWork.IIncidencias.Incidencia_getANSByEmp(Entity);
        }

        public IEnumerable<PorcentajeCumplimientoDTO> getPorcentajeCumplimiento(FilterIncidenciaByEmpDate entity)
        {
            return _unitOfWork.IIncidencias.getPorcentajeCumplimiento(entity);
        }
    }
}
