using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Respuesta.DTO.incidencia;
using System;
using System.Collections.Generic;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Solicitud.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;

namespace Logica.Negocio.Interfaces.Logic.incidencia
{
    public interface IIncidenciasLogic
    {
        bool Update(t_incidencias obj);
        int Insert(GetIncidenciaArchivosComentarios obj);
        int Insert(t_incidencias obj);
        IEnumerable<t_incidencias> GetList();
        t_incidencias GetById(int id);
        IEnumerable<incidenciasGridDTO> getIncidenciasByRolAndUsuarioid(string rol, in int id, int idNivel);
        incidenciaArchivosComentarios_complete getIncidenciaArchivosComentariosxIncidencia(int id);
        IEnumerable<usuariosAsignar> obtenerUsuariosParaAsignar(in int id);
        List<incidenciaComentariosArchivos_getCompleteFilter> getIncidenciasArchivosComentariosFilter();
        bool updateincidenciaTipifica(t_incidencias tIncidencias);
        public bool cumpleANS(int diasRespuesta, t_incidencias incidencia);
        public personas getUsuarioASignado(t_incidencias incidencia);
        public personas getUsuarioRegistro(t_incidencias incidencia);
        public string getLinkIncidencia();
        public List<incidenciaByTipifFecha> getIncidenciasByTipifFecha(FilterIncidenciaByFechaById Entity);
        public List<incidenciaBySistemaFecha> getIncidenciasBySistemaFecha(FilterIncidenciaByFechaById Entity);
        public incidenciaByTipifList getIncidenciasByTipifList(FilterIncidenciaByTipifListByEmp Entity);
        public incidenciaByTipifListDecimal Incidencia_conteoHorasByIncidenciaSistema(FilterIncidenciaByMonthByEmp Entity);
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_sol(FilterIncidenciaByMonth Entity);
        public seriesAtencionSolicitudes getANSByMonth_sol(FilterIncidenciaANSByMonth Entity);
        incidenciaDetailsEmailDTO getIncidenciaDetaliByEmail(in int incidenciaId);
        public List<object> obtenerIncidenciasSistemaPorIdUsuario(int idUsuario);
        IEnumerable<incidenciasGridDTO> getTicketsGerenteCliente(in int id);
        IEnumerable<incidenciasGridDTO> getTicketsGerenteSoporte(in int id);
        public incidenciaByTipifList getIncidenciasBySistemaFecha_sol(FilterIncidenciaByMonth Entity);
        public IncidenciasByEtapa getIncidenciasByEtapa(onlyIdAndRol Entity);
        public IncidenciasByEtapa getIncidenciasByEtapaCliente(onlyIdAndRol Entity);
        public IncidenciasByEstado getIncidenciasByEstado(onlyIdAndRol Entity);
        public IncidenciasByEstado getIncidenciasByEstadoCliente(onlyIdAndRol Entity);
        public incidenciaByTipifList Incidencias_getEstadosByUsuario(onlyIdAndRol Entity);
        public incidenciaByTipifList Incidencias_getEstadosByCliente(onlyIdAndRol entity);
        public IncidenciasByEtapa getIncidenciasByEtapaGen();
        public incidenciaByTipifList Incidencias_getEstadosByUsuarioGen();
        public IncidenciasByEstado getIncidenciasByEstadoGen();
        public incidenciaByTipifList getIncidenciasBySistemaFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity);
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity);
        public List<IncidenciaHorasByMes> Incidencias_getHorasByMes(FilterIncidenciaByEmpMonth Entity);
        public List<IncidenciaHorasUsuarioAsignadoSistemaByMonth> Incidencia_getHorasUsuarioAsignadoSistemaByMonth(FilterIncidenciaByEmpMonth Entity);
        public List<IncidenciasHorasSistemaByMonth> Incidencia_getHorasUsuarioAsignadoByMonth(FilterIncidenciaByEmpMonth Entity);
        public List<IncidenciaHorasUsuarioAsignadoByMonth> Incidencias_getHorasSistemaByMonth(FilterIncidenciaByEmpMonth Entity);
        IEnumerable<reporteIncidenciaResponseDTO> getReporteIncidenciasByFechas(reporteIncidenciaDTO reporteIncidenciaDto);
        public List<incidenciaFactorRendimientoAsignado> Incidencia_getFactorRendimientoAsignado(FIlterIncidenciaByAsigMonth Entity);
        public List<IncidenciaGetTable1> Incidencia_getTicketHorasTable1(FilterIncidenciaByMonthYearEmp Entity);
        public List<incidencia_dataIntLabelString> Incidencia_getANSByEmp(FilterIncidenciaByEmpDate Entity);

        IEnumerable<PorcentajeCumplimientoDTO> getPorcentajeCumplimiento(FilterIncidenciaByEmpDate entity);
    }
}
