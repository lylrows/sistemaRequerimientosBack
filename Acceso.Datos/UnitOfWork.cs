using System;
using System.Collections.Generic;
using System.Text;
using Acceso.Datos.Implementacion.Repositorios;
using Acceso.Datos.Implementacion.Repositorios.persona;
using Acceso.Datos.Implementacion.Repositorios.configuracion;
using Acceso.Datos.Implementacion.Repositorios.incidencia;
using Acceso.Datos.Implementacion.Repositorios.login;
using Repositorios.Interfaces;
using Repositorios.Interfaces.persona;
using Repositorios.Interfaces.configuracion;
using Repositorios.Interfaces.login;
using Unidad.Trabajo;
using Repositorios.Interfaces.incidencia;
using Repositorios.Interfaces.correo;
using Acceso.Datos.Implementacion.Repositorios.correo;
using Acceso.Datos.Implementacion.Repositorios.empresas;
using Repositorios.Interfaces.empresas;
using Repositorios.Interfaces.mejoras;
using Acceso.Datos.Implementacion.Repositorios.mejora;
using Acceso.Datos.Implementacion.Repositorios.secuencial;
using Repositorios.Interfaces.secuencial;
using Repositorios.Interfaces.emision;
using Acceso.Datos.Implementacion.Repositorios.emision;

namespace Acceso.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccesosRepository IAccesos { get; }
        public IT_personasRepository IT_personas { get; }
        public IMenuRepository IMenu { get; }
        public IParametrosRepository IParametros { get; }
        public IParametroDetallesRepository IParametroDetalles { get; }
        public IConstantesRepository IConstantes { get; }
        public IEmpresasRepository IEmpresas { get; }
        public ICredencialesRepository ICredenciales { get; }
        public ISistemasRepository ISistemas { get; }
        public IEmpresaSistemaUsuariosRepository IEmpresaSistemaUsuarios { get; }
        public IEmpresaSistemasRepository IEmpresaSistemas { get; }
        public IModificacionActivoRepository IModificacionActivo { get; }
        public IIncidenciaArchivosRepository IIncidenciaArchivos { get; }
        public IIncidenciaAsignacionesRepository IIncidenciaAsignaciones { get; }
        public IIncidenciaComentariosRepository IIncidenciaComentarios { get; }
        public IIncidenciasRepository IIncidencias { get; }
        public IEmpresaANSRepository IEmpresaANS { get; }
        public IEmpresaHorariosRepository IEmpresaHorarios { get; }
        public IIncidenciaSolucionArchivosRepository IIncidenciaSolucionArchivos { get; }
        public IIncidenciaSolucionPalabrasClaveRepository IIncidenciaSolucionPalabrasClave { get; }
        public IIncidenciaSolucionRepository IIncidenciaSolucion { get; }
        public ICorreoRepository ICorreo { get; }
        public IIncidenciashistorialRepository IIncidenciashistorial { get; }
        public ITipificacionesempresaRepository ITipificacionesempresa { get; }
        public ITipoincidenciasempresaRepository ITipoincidenciasempresa { get; }
        public IMejorasRepository IMejoras { get; }
        public IMejoraAsignacionesRepository IMejoraAsignaciones { get; }
        public IMejoraArchivosRepository IMejoraArchivos { get; }
        public IMejoraRegistroActividadesRepository IRegistroActividades { get; }
        public ISecuencialesidRepository ISecuencialesid { get; }
        public ITablasRepository ITablas { get; }
        public IPrioridadhistorialRepository IPrioridadhistorial { get; }

        public IPedidosRepository IPedidos { get; }
        public IPedidosarchivosRepository IPedidosarchivos { get; }

        public IPedidosrespuestaRepository IPedidosrespuesta { get; }

        public IMuralRepository IMural { get; }

        public ITagsRepository ITags { get; }

        public ITagsincidenciasRepository ITagsincidencias { get; }

        public UnitOfWork(string connectionString)
        {
            IAccesos = new accesosRepository(connectionString);
            ICredenciales = new credencialesRepository(connectionString);
            IT_personas = new personasRepository(connectionString);
            IMenu = new menuRepository(connectionString);
            ICredenciales = new credencialesRepository(connectionString);
            IParametros = new parametrosRepository(connectionString);
            IParametroDetalles = new parametroDetallesRepository(connectionString);
            IConstantes = new constantesRepository(connectionString);
            IEmpresas = new empresasRepository(connectionString);
            IModificacionActivo = new modificacionActivoRepository(connectionString);
            IEmpresaSistemas = new empresaSistemasRepository(connectionString);
            ISistemas = new sistemasRepository(connectionString);
            IEmpresaSistemaUsuarios = new empresaSistemaUsuariosRepository(connectionString);
            ITipificacionesempresa = new tipificacionesEmpresaRepository(connectionString);
            ITipoincidenciasempresa = new tipoIncidenciasEmpresaRepository(connectionString);
            IIncidencias = new incidenciasRepository(connectionString, IParametroDetalles,ITipificacionesempresa);
            IIncidenciaComentarios = new incidenciaComentariosRepository(connectionString);
            IIncidenciaAsignaciones = new incidenciaAsignacionesRepository(connectionString);
            IIncidenciaArchivos = new incidenciaArchivosRepository(connectionString);
            IEmpresaHorarios = new empresaHorariosRepository(connectionString);
            IEmpresaANS = new empresaANSRepository(connectionString);
            IIncidenciaSolucion = new incidenciaSolucionRepository(connectionString);
            IIncidenciaSolucionArchivos = new incidenciaSolucionArchivosRepository(connectionString);
            IIncidenciaSolucionPalabrasClave = new incidenciaSolucionPalabrasClaveRepository(connectionString);
            ICorreo = new correoRepository(connectionString);
            IIncidenciashistorial = new incidenciasHistorialRepository(connectionString);
            IMejoras = new mejorasRepository(connectionString);
            IMejoraAsignaciones = new mejoraAsignacionesRepository(connectionString);
            IMejoraArchivos = new mejoraArchivosRepository(connectionString);
            IRegistroActividades = new mejoraRegistroActividadesRepository(connectionString);
            ISecuencialesid = new secuencialesIdRepository(connectionString);
            ITablas = new tablasRepository(connectionString);
            IPrioridadhistorial = new prioridadHistorialRepository(connectionString);
            IPedidos = new pedidosRepository(connectionString);
            IPedidosarchivos = new pedidosArchivosRepository(connectionString);
            IPedidosrespuesta = new pedidosRespuestaRepository(connectionString);
            IMural = new muralRepository(connectionString);
            ITags = new tagsRepository(connectionString);
            ITagsincidencias = new tagsIncidenciasRepository(connectionString);
        }
    }
}
