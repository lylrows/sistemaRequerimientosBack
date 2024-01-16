using System;
using System.Collections.Generic;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.correo;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.correo;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Mapeo.Base.Datos.persona;
using Modelos.Datos.Respuesta.DTO;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/[controller]")]
    [ApiController]
    public class incidenciaComentariosController : ControllerBase
    {
        private IIncidenciasLogic _logicIncidencia;
        private ICorreoLogic _correo;
        private IIncidenciaComentariosLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public incidenciaComentariosController(IIncidenciasLogic t_logicIncidencia, ICorreoLogic e_correo, IIncidenciaComentariosLogic t_logic)
        {
            _logic = t_logic;
            _logicIncidencia = t_logicIncidencia;
            _correo = e_correo;
        }
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
                List<t_incidenciaComentarios> comentarios = new List<t_incidenciaComentarios>();
                comentarios = (List<t_incidenciaComentarios>) _logic.GetList();
                return Ok(responseDTO.Success(responseDTO, comentarios.FindAll( x => x.idIncidencia == id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getComentariosByIdincidencia/{id:int}")]
        public IActionResult getComentariosByIdincidencia(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getComentariosByIdincidencia(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_incidenciaComentarios obj)
        {
            try
            {
                obj.fechaRegistro = GetLimaDateTimeNow();
                return Ok(responseDTO.Success(responseDTO, _logic.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("InsertNotificar")]
        public IActionResult InsertNotificar([FromBody] t_incidenciaComentarios obj)
        {
            obj.fechaRegistro = GetLimaDateTimeNow();
            int id = _logic.Insert(obj);
            t_incidencias obj2 = new t_incidencias();
            obj2 = _logicIncidencia.GetById(obj.idIncidencia);
            personas usuarioRegistro = new personas();
            personas usuarioAsignado = new personas();
            incidenciaDetailsEmailDTO datos = new incidenciaDetailsEmailDTO();
            datos = _logicIncidencia.getIncidenciaDetaliByEmail(obj.idIncidencia);
            usuarioAsignado = _logicIncidencia.getUsuarioASignado(obj2);
            usuarioRegistro = _logicIncidencia.getUsuarioRegistro(obj2);
            string link = _logicIncidencia.getLinkIncidencia();
            try
            {                              
                DatosSMTP smtp = new DatosSMTP();
                DatosEmail email = new DatosEmail();
                email.Para.Add(usuarioRegistro.email);
                email.Titulo = "SGR - Notificación de respuesta : ID " + obj2.idTicket;
                email.Para.Add(usuarioRegistro.email);
                string bodyhtml = "C:\\SGRFiles\\html\\incEditReg.html";
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
                return Ok(responseDTO.Success(responseDTO, id));
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
        public IActionResult Update([FromBody] t_incidenciaComentarios obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
