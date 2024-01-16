using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.correo;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Solicitud;
using Modelos.Datos.Respuesta.DTO.incidencia;
using Modelos.Datos.Utils;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Modelos.Datos.Respuesta.DTO;
using Modelos.Datos.Solicitud.DTO;
using Modelos.Datos.Solicitud.DTO.incidencia;
using System.Collections.Generic;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/[controller]")]
    [ApiController]
    public class incidenciasController : ControllerBase
    {
        private IIncidenciasLogic _logic;
        private ICorreoLogic _correo;
        private readonly AppSettings _appSettings;
        public ResponseDTO responseDTO = new ResponseDTO();
        public incidenciasController(IIncidenciasLogic t_logic,ICorreoLogic e_correo, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _logic = t_logic;
            _correo = e_correo;
            _appSettings = appSettings.Value;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpGet]
        [Route("obtenerUsuariosParaAsignar/{id:int}")]
        public IActionResult obtenerUsuariosParaAsignar(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.obtenerUsuariosParaAsignar(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getIncidenciasByRolAndUsuarioid/{rol}/{id:int}/{idNivel:int}")]
        public IActionResult getIncidenciasByRolAndUsuarioid(string rol, int id, int idNivel)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByRolAndUsuarioid(rol, id, idNivel)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("getTicketsGerenteCliente/{id:int}")]
        public IActionResult getTicketsGerenteCliente(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getTicketsGerenteCliente(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("getTicketsGerenteSoporte/{id:int}")]
        public IActionResult getTicketsGerenteSoporte(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getTicketsGerenteSoporte(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("getReporteIncidenciasByFechas")]
        public IActionResult getReporteIncidenciasByFechas([FromBody] reporteIncidenciaDTO obj)
        {
            responseDTO = new ResponseDTO();
            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getReporteIncidenciasByFechas(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("insertObj")]
        public IActionResult insertObj([FromBody] GetIncidenciaArchivosComentarios obj)
        {
            try
            {
                obj.incidencia.fechaAtencion = null;
                int result = _logic.Insert(obj);
                string link = _logic.getLinkIncidencia();
                if (result>0)
                {
                    personas usuarioRegistro = new personas();
                    personas usuarioAsignado = new personas();
                    incidenciaDetailsEmailDTO datos = new incidenciaDetailsEmailDTO();
                    usuarioAsignado = _logic.getUsuarioASignado(obj.incidencia);
                    usuarioRegistro = _logic.getUsuarioRegistro(obj.incidencia);
                    datos = _logic.getIncidenciaDetaliByEmail(obj.incidencia.id);
                    try
                    {
                        
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP();
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail();
                        email.Para.Add(usuarioRegistro.email);
                        email.Titulo = "SGR - Registo de incidencia : ID " + result;
                        string bodyhtml = "C:\\SGRFiles\\html\\incInsReg.html";
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", obj.incidencia.nombre);
                        fmt = fmt.Replace("[IDINC]", result.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", obj.incidencia.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);

                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se insertó pero no se pudo enviar el correo al usuario de registro"));
                    }
                    try
                    {
                        
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP();
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail();
                        email.Para.Add(usuarioAsignado.email);
                        email.Titulo = "SGR - Notificación de nueva incidencia : ID " + result;

                        string bodyhtml = "C:\\SGRFiles\\html\\incInsAsig.html";
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", obj.incidencia.nombre);
                        fmt = fmt.Replace("[IDINC]", result.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", obj.incidencia.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);
                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se insertó pero no se pudo enviar el correo al usuario asignado"));
                    }
                }
                ; return Ok(responseDTO.Success(responseDTO, result));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_incidencias obj)
        {
            try
            {
                obj.fechaActualiza = null;
                obj.fechaAtencion = null;
                obj.cumplioANS = -1;
                int result = _logic.Insert(obj);
                string link = _logic.getLinkIncidencia();
                if (result > 0)
                {
                    personas usuarioRegistro = new personas();
                    personas usuarioAsignado = new personas();
                    incidenciaDetailsEmailDTO datos = new incidenciaDetailsEmailDTO();
                    datos = _logic.getIncidenciaDetaliByEmail(obj.id);
                    usuarioAsignado = _logic.getUsuarioASignado(obj);
                    usuarioRegistro = _logic.getUsuarioRegistro(obj);
                    try
                    {
                        
                        DatosSMTP smtp = new DatosSMTP();
                        DatosEmail email = new DatosEmail();
                        email.Para.Add(usuarioRegistro.email);
                        email.Titulo = "SGR - Registo de incidencia : ID " + result;

                        string bodyhtml = "C:\\SGRFiles\\html\\incInsReg.html";
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", obj.nombre);
                        fmt = fmt.Replace("[IDINC]", result.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", obj.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);

                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se insertó pero no se pudo enviar el correo al usuario de registro"));
                    }
                    try
                    {
                        
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP();
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail();
                        email.Para.Add(usuarioAsignado.email);
                        email.Titulo = "SGR - Notificación de nueva incidencia : ID " + result;

                        string bodyhtml = "C:\\SGRFiles\\html\\incInsAsig.html";
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", obj.nombre);
                        fmt = fmt.Replace("[IDINC]", result.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", obj.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);
                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se insertó pero no se pudo enviar el correo al usuario asignado"));
                    }
                }
                 return Ok(responseDTO.Success(responseDTO, obj.id));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("updateincidenciaTipifica")]
        public IActionResult updateincidenciaTipifica([FromBody] t_incidencias obj)
        {
            try
            {
                
                var objUpdate = _logic.GetById(obj.id);
                bool estadosDiferentes = (obj.idEstado != objUpdate.idEstado);
                objUpdate.idTipoIncidencia = obj.idTipoIncidencia;
                objUpdate.idTipificacion = obj.idTipificacion;
                objUpdate.idEstado = obj.idEstado;
                objUpdate.idPrioridad = obj.idPrioridad;
                objUpdate.horasEstimadas = obj.horasEstimadas;
                objUpdate.horasEjecutadas = obj.horasEjecutadas;
                if (obj.idEstado == 2)
                {
                    objUpdate.fechaAtencion = GetLimaDateTimeNow();                    
                    if (objUpdate.fechaMaximaAtencion > objUpdate.fechaAtencion)
                    {
                        objUpdate.cumplioANS = 1;
                    }
                    else
                    {
                        objUpdate.cumplioANS = 0;
                    }
                    
                }
                if (obj.idEstado == 3)
                {
                    TimeSpan horasFaltan = TimeSpan.FromHours((objUpdate.fechaMaximaAtencion.Value - objUpdate.fechaAtencion.Value).TotalHours);
                    if (horasFaltan.TotalHours > 0)
                    {
                        objUpdate.fechaMaximaAtencion = DateTime.Now;
                        objUpdate.fechaMaximaAtencion = objUpdate.fechaMaximaAtencion.Value.Add(horasFaltan);
                        int inicioTrabajoHoras = 9;
                        int finTrabajoHoras = 18;
                        DateTime fechaMaximaAtencion = objUpdate.fechaMaximaAtencion.Value;
                        if (fechaMaximaAtencion.Hour >= finTrabajoHoras)
                        {
                            int excesoHoras = fechaMaximaAtencion.Hour - finTrabajoHoras;
                            int excesoMinutos = fechaMaximaAtencion.Minute;
                            fechaMaximaAtencion = fechaMaximaAtencion.AddDays(1).Date.AddHours(inicioTrabajoHoras).AddHours(excesoHoras).AddMinutes(excesoMinutos);
                            if (fechaMaximaAtencion.DayOfWeek == DayOfWeek.Saturday)
                            {
                                fechaMaximaAtencion = fechaMaximaAtencion.AddDays(2);
                            }
                            else if (fechaMaximaAtencion.DayOfWeek == DayOfWeek.Sunday)
                            {
                                fechaMaximaAtencion = fechaMaximaAtencion.AddDays(1);
                            }
                        }
                        objUpdate.fechaMaximaAtencion = fechaMaximaAtencion;
                    }
                    
                    objUpdate.cumplioANS = -1;
                }
                bool updateTicket = _logic.Update(objUpdate);

                if (updateTicket && estadosDiferentes)//solo si el estado es diferente envia correo
                {
                    personas usuarioRegistro = new personas();
                    personas usuarioAsignado = new personas();
                    incidenciaDetailsEmailDTO datos = new incidenciaDetailsEmailDTO();
                    datos = _logic.getIncidenciaDetaliByEmail(obj.id);
                    usuarioAsignado = _logic.getUsuarioASignado(obj);
                    usuarioRegistro = _logic.getUsuarioRegistro(obj);
                    string link = _logic.getLinkIncidencia();
                    try
                    {
                        
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP();
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail();
                        email.Para.Add(usuarioRegistro.email);
                        if(obj.idEstado == 3){
                            email.ConCopia.Add(usuarioAsignado.email);
                        }
                        email.Titulo = "SGR - Notificación de edición de incidencia : ID " + objUpdate.idTicket;
                        //email.Para.Add(usuarioRegistro.email);

                        string bodyhtml = "C:\\SGRFiles\\html\\incEditReg.html";
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", objUpdate.nombre);
                        fmt = fmt.Replace("[IDINC]", objUpdate.idTicket.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", objUpdate.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);
                        fmt = fmt.Replace("[COMMT]", datos.comentario);
                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };
                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se editó pero no se pudo enviar el correo al usuario de registro"));
                    }
                  
                }
                return Ok(responseDTO.Success(responseDTO, updateTicket));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        private DateTime GetLimaDateTimeNow()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo limaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime limaDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, limaTimeZone);
            return limaDateTime;
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_incidencias obj)
        {
            try
            {
                if (obj.idEstado == 2)
                {
                    obj.fechaAtencion = GetLimaDateTimeNow();
                    if (obj.fechaMaximaAtencion > obj.fechaAtencion)
                    {
                        obj.cumplioANS = 1;
                    }
                    else
                    {
                        obj.cumplioANS = 0;
                    }
                }
               
                t_incidencias obj2 = new t_incidencias();
                obj2 = _logic.GetById(obj.id);
                if (_logic.Update(obj) && obj.idEstado != obj2.idEstado)//solo si el estado es diferente envia correo
                {
                    personas usuarioRegistro = new personas();
                    personas usuarioAsignado = new personas();
                    incidenciaDetailsEmailDTO datos = new incidenciaDetailsEmailDTO();
                    datos = _logic.getIncidenciaDetaliByEmail(obj.id);
                    usuarioAsignado = _logic.getUsuarioASignado(obj);
                    usuarioRegistro = _logic.getUsuarioRegistro(obj);
                    string link = _logic.getLinkIncidencia();
                    try
                    {                        
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP();
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail();
                        email.Para.Add(usuarioRegistro.email);
                        email.Titulo = "SGR - Notificación de edición de incidencia : ID " + obj2.idTicket;

                        string bodyhtml = _appSettings.IncUpdateUsuarioRegistro;
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", obj2.nombre);
                        fmt = fmt.Replace("[IDINC]", obj2.idTicket.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", obj2.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);
                        fmt = fmt.Replace("[COMMT]", datos.comentario);
                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se editó pero no se pudo enviar el correo al usuario de registro"));
                    }
                    try
                    {
                        
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP smtp = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosSMTP();
                        Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail email = new Modelos.Datos.Mapeo.Base.Datos.correo.DatosEmail();
                        email.Para.Add(usuarioAsignado.email);
                        email.Titulo = "SGR - Notificación de edición de incidencia : ID " + obj2.idTicket;

                        string bodyhtml = "C:\\SGRFiles\\html\\incEditAsig.html";
                        string fmt = System.IO.File.ReadAllText(bodyhtml);
                        fmt = fmt.Replace("[NOMBREUSREG]", usuarioRegistro.nombres);
                        fmt = fmt.Replace("[APUSREG]", usuarioRegistro.apellidos);
                        fmt = fmt.Replace("[NOMBREUSASIG]", usuarioAsignado.nombres);
                        fmt = fmt.Replace("[APUSASIG]", usuarioAsignado.apellidos);
                        fmt = fmt.Replace("[NOMBREINC]", obj.nombre);
                        fmt = fmt.Replace("[IDINC]", obj2.idTicket.ToString());
                        fmt = fmt.Replace("[INCFECHAREG]", obj.fechaRegistro.ToString());

                        fmt = fmt.Replace("[ESTD]", datos.estado);
                        fmt = fmt.Replace("[INCPRIOR]", datos.prioridad);
                        fmt = fmt.Replace("[NOMBRESIST]", datos.nombreSistema);
                        fmt = fmt.Replace("[RAZSOC]", datos.razonSocial);
                        fmt = fmt.Replace("[COMMT]", datos.comentario);
                        email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                        _correo.enviarCorreo(email, smtp);
                    }
                    catch (Exception e)
                    {
                        ; return Ok(responseDTO.Success(responseDTO, "se editó pero no se pudo enviar el correo al usuario asignado"));
                    }

                }
                ; return Ok(responseDTO.Success(responseDTO,true));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("getIncidenciaComentariosArchivosByIncidencia/{id:int}")]
        public IActionResult getIncidenciaComentariosArchivos(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciaArchivosComentariosxIncidencia(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpGet]
        [Route("getIncidenciaComentariosArchivosByFilter/")]
        public IActionResult getIncidenciaComentariosArchivosByFilter()
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasArchivosComentariosFilter()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("getIncidenciaByTipifFecha/")]
        public IActionResult getIncidenciaByTipifFecha(FilterIncidenciaByMonth Entity)
        {

            try
            {
                ;
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByTipifFecha_sol(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciaANSByMonth/")]
        public IActionResult getIncidenciaANSByMonth(FilterIncidenciaANSByMonth Entity)
        {

            try
            {
                ;
                return Ok(responseDTO.Success(responseDTO, _logic.getANSByMonth_sol(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidencia_conteoHorasByIncidenciaSistema/")]
        public IActionResult Incidencia_conteoHorasByIncidenciaSistema(FilterIncidenciaByMonthByEmp Entity)
        {

            try
            {
                ;
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencia_conteoHorasByIncidenciaSistema(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasByTipifList/")]
        public IActionResult getIncidenciasByTipifList(FilterIncidenciaByTipifListByEmp Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByTipifList(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasBySistemaFecha/")]
        public IActionResult getIncidenciasBySistemaFecha(FilterIncidenciaByMonth Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasBySistemaFecha_sol(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasSistemaByIdUsuario/")]
        public IActionResult getIncidenciasSistemaByIdUsuario(int idUsuario)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.obtenerIncidenciasSistemaPorIdUsuario(idUsuario)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasByEtapa/")]
        public IActionResult getIncidenciasByEtapa(onlyIdAndRol Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByEtapa(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasByEtapaCliente/")]
        public IActionResult getIncidenciasByEtapaCliente(onlyIdAndRol Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByEtapaCliente(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("getIncidenciasByEstado/")]
        public IActionResult getIncidenciasByEstado(onlyIdAndRol Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByEstado(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasByEstadoCliente/")]
        public IActionResult getIncidenciasByEstadoCliente(onlyIdAndRol Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByEstadoCliente(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getEstadosByUsuario/")]
        public IActionResult getEstadosByUsuario(onlyIdAndRol Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencias_getEstadosByUsuario(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getEstadosByCliente/")]
        public IActionResult getEstadosByCliente(onlyIdAndRol Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencias_getEstadosByCliente(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        //
        [HttpPost]
        [Route("getIncidenciasByEtapaGen/")]
        public IActionResult getIncidenciasByEtapaGen()
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByEtapaGen()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getEstadosByUsuarioGen/")]
        public IActionResult Incidencias_getEstadosByUsuarioGen()
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencias_getEstadosByUsuarioGen()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasByEstadoGen/")]
        public IActionResult getIncidenciasByEstadoGem()
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByEstadoGen()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciasBySistemaFechaByEmp/")]
        public IActionResult getIncidenciasBySistemaFechaByEmp(FilterIncidenciaByMonthByEmp Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasBySistemaFecha_solByEmp(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("getIncidenciaByTipifFechaByEmp/")]
        public IActionResult getIncidenciaByTipifFechaByEmp(FilterIncidenciaByMonthByEmp Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciasByTipifFecha_solByEmp(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("Incidencias_getHorasByMes/")]
        public IActionResult Incidencias_getHorasByMes(FilterIncidenciaByEmpMonth Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencias_getHorasByMes(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("Incidencia_getHorasUsuarioAsignadoSistemaByMonth/")]
        public IActionResult Incidencia_getHorasUsuarioAsignadoSistemaByMonth(FilterIncidenciaByEmpMonth Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencia_getHorasUsuarioAsignadoSistemaByMonth(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("Incidencia_getHorasUsuarioAsignadoByMonth/")]
        public IActionResult Incidencia_getHorasUsuarioAsignadoByMonth(FilterIncidenciaByEmpMonth Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencia_getHorasUsuarioAsignadoByMonth(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("Incidencias_getHorasSistemaByMonth/")]
        public IActionResult Incidencias_getHorasSistemaByMonth(FilterIncidenciaByEmpMonth Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencias_getHorasSistemaByMonth(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("Incidencia_getFactorRendimientoAsignado/")]
        public IActionResult Incidencia_getFactorRendimientoAsignado(FIlterIncidenciaByAsigMonth Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencia_getFactorRendimientoAsignado(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
        [HttpPost]
        [Route("Incidencia_getTicketHorasTable1/")]
        public IActionResult Incidencia_getTicketHorasTable1(FilterIncidenciaByMonthYearEmp Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencia_getTicketHorasTable1(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("Incidencia_getANSByEmp/")]
        public IActionResult Incidencia_getANSByEmp(FilterIncidenciaByEmpDate Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.Incidencia_getANSByEmp(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("getPorcentajeCumplimiento/")]
        public IActionResult getPorcentajeCumplimiento(FilterIncidenciaByEmpDate Entity)
        {

            try
            {
                return Ok(responseDTO.Success(responseDTO, _logic.getPorcentajeCumplimiento(Entity)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


    }
}
