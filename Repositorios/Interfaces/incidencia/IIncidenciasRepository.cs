using System;
using System.Collections.Generic;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Solicitud.DTO;
using Modelos.Datos.Solicitud.DTO.incidencia;

namespace Repositorios.Interfaces.incidencia
{
    public interface IIncidenciasRepository : IRepository<t_incidencias>
    {
        IEnumerable<incidenciasGridDTO> getIncidenciasByRolAndUsuarioid(string rol, in int id, int idNivel);
        incidenciaArchivosComentarios_complete getIncidenciaArchivosComentariosxIncidencia(int id);
        List<usuariosAsignar> obtenerUsuariosParaAsignar(in int idIncidencia);
        List<incidenciaComentariosArchivos_getCompleteFilter> getIncidenciasArchivosComentariosFilter();
        Modelos.Datos.Mapeo.Base.Datos.correo.ResultadoEnvio enviarCorreo(Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email, Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp);
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
        public IncidenciasByEstado getIncidenciasByEstado(onlyIdAndRol Entity);
        public IncidenciasByEstado getIncidenciasByEstadoCliente(onlyIdAndRol Entity);
        public IncidenciasByEtapa getIncidenciasByEtapaCliente(onlyIdAndRol Entity);
        public incidenciaByTipifList Incidencias_getEstadosByUsuario(onlyIdAndRol Entity);
        public incidenciaByTipifList Incidencias_getEstadosByCliente(onlyIdAndRol entity);
        public IncidenciasByEtapa getIncidenciasByEtapaGen();
        public incidenciaByTipifList Incidencias_getEstadosByUsuarioGen();
        public IncidenciasByEstado getIncidenciasByEstadoGen();
        public incidenciaByTipifList getIncidenciasBySistemaFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity);
        public List<incidenciaByTipifFecha_sol> getIncidenciasByTipifFecha_solByEmp(FilterIncidenciaByMonthByEmp Entity);
        int getIdSecuencialTicket(in int incidenciaIdEmpSist, int i);
        public List<IncidenciaHorasByMes> Incidencias_getHorasByMes(FilterIncidenciaByEmpMonth Entity);
        public List<IncidenciaHorasUsuarioAsignadoSistemaByMonth> Incidencia_getHorasUsuarioAsignadoSistemaByMonth(FilterIncidenciaByEmpMonth Entity);
        public List<IncidenciasHorasSistemaByMonth> Incidencia_getHorasUsuarioAsignadoByMonth(FilterIncidenciaByEmpMonth Entity);
        public List<IncidenciaHorasUsuarioAsignadoByMonth> Incidencias_getHorasSistemaByMonth(FilterIncidenciaByEmpMonth Entity);
        IEnumerable<reporteIncidenciaResponseDTO> getReporteIncidenciasByFechas(reporteIncidenciaDTO objDto);
        public List<incidenciaFactorRendimientoAsignado> Incidencia_getFactorRendimientoAsignado(FIlterIncidenciaByAsigMonth Entity);
        public List<IncidenciaGetTable1> Incidencia_getTicketHorasTable1(FilterIncidenciaByMonthYearEmp Entity);
        public List<incidencia_dataIntLabelString> Incidencia_getANSByEmp(FilterIncidenciaByEmpDate Entity);

        IEnumerable<PorcentajeCumplimientoDTO> getPorcentajeCumplimiento(FilterIncidenciaByEmpDate entity);
    }
}
