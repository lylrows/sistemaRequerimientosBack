

using Repositorios.Interfaces;
using Repositorios.Interfaces.persona;
using Repositorios.Interfaces.configuracion;
using Repositorios.Interfaces.incidencia;
using Repositorios;
using Repositorios.Interfaces.login;
using Repositorios.Interfaces.correo;
using Repositorios.Interfaces.empresas;
using Repositorios.Interfaces.mejoras;
using Repositorios.Interfaces.secuencial;
using Repositorios.Interfaces.emision;

namespace Unidad.Trabajo
{
    public interface IUnitOfWork
    {
        IAccesosRepository IAccesos { get; }
        IT_personasRepository IT_personas { get; }
        IMenuRepository IMenu { get; }
        IParametroDetallesRepository IParametroDetalles { get; }
        IParametrosRepository IParametros { get; }
        IConstantesRepository IConstantes { get; }
        IEmpresasRepository IEmpresas { get; }
        IModificacionActivoRepository IModificacionActivo { get; }
        ISistemasRepository ISistemas { get; }
        ICredencialesRepository ICredenciales { get; }
        IEmpresaSistemasRepository IEmpresaSistemas { get; }
        IEmpresaSistemaUsuariosRepository IEmpresaSistemaUsuarios { get; }
        IIncidenciaArchivosRepository IIncidenciaArchivos { get; }
        IIncidenciaAsignacionesRepository IIncidenciaAsignaciones { get; }
        IIncidenciaComentariosRepository IIncidenciaComentarios { get; }
        IIncidenciasRepository IIncidencias { get; }
        IEmpresaANSRepository IEmpresaANS { get; }
        IEmpresaHorariosRepository IEmpresaHorarios { get; }
        IIncidenciaSolucionRepository IIncidenciaSolucion { get; }
        IIncidenciaSolucionPalabrasClaveRepository IIncidenciaSolucionPalabrasClave { get; }
        IIncidenciaSolucionArchivosRepository IIncidenciaSolucionArchivos { get; }
        ICorreoRepository ICorreo { get; }
        IIncidenciashistorialRepository IIncidenciashistorial { get; }
        ITipificacionesempresaRepository ITipificacionesempresa { get; }
        ITipoincidenciasempresaRepository ITipoincidenciasempresa { get; }
        IMejorasRepository IMejoras { get; }
        IMejoraArchivosRepository IMejoraArchivos { get; }
        IMejoraRegistroActividadesRepository IRegistroActividades { get; }
        ISecuencialesidRepository ISecuencialesid { get; }
        ITablasRepository ITablas { get; }
        IPrioridadhistorialRepository IPrioridadhistorial { get; }
        IMejoraAsignacionesRepository IMejoraAsignaciones { get; }
        IPedidosRepository IPedidos { get; }
        IPedidosarchivosRepository IPedidosarchivos { get; }
        IPedidosrespuestaRepository IPedidosrespuesta { get; }
        IMuralRepository IMural { get; }
        ITagsRepository ITags { get; }
        ITagsincidenciasRepository ITagsincidencias { get; }
    }
}