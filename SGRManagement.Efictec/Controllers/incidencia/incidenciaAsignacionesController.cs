using System;
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
    public class incidenciaAsignacionesController : ControllerBase
    {
        private IIncidenciaAsignacionesLogic _logic;
        private IIncidenciasLogic _IncLogic;
        private ICorreoLogic _correo;
        public ResponseDTO responseDTO = new ResponseDTO();
        public incidenciaAsignacionesController(IIncidenciaAsignacionesLogic t_logic, ICorreoLogic e_correo, IIncidenciasLogic i_logic)
        {
            _logic = t_logic;
            _correo = e_correo;
            _IncLogic = i_logic;
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
                ; return Ok(responseDTO.Success(responseDTO, _logic.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getTicketsPendientes/{id:int}")]
        public IActionResult getTicketsPendientes(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getTicketsPendientes(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getNivelSoporteById/{id:int}")]
        public IActionResult getNivelSoporteById(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getNivelSoporteById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_incidenciaAsignaciones obj)
        {
            try
            {
                int result = _logic.Insert(obj);
                personas usuarioRegistro = new personas();
                personas usuarioAsignado = new personas();
                incidenciaDetailsEmailDTO datos = new incidenciaDetailsEmailDTO();
                usuarioAsignado = _logic.getUsuarioASignado(obj.idIncidencia);
                usuarioRegistro = _logic.getUsuarioRegistro(obj.idIncidencia);
                datos = _logic.getIncidenciaDetaliByEmail(obj.idIncidencia);
                t_incidencias obj2 = _IncLogic.GetById(obj.idIncidencia);
                DatosSMTP smtp = new DatosSMTP();
                DatosEmail email = new DatosEmail();
                email.Para.Add(usuarioAsignado.email);
                email.Titulo = "SGR - Notificación de nueva incidencia : ID " + obj2.idTicket;

                string bodyhtml = "C:\\SGRFiles\\html\\incInsAsig.html";
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
                email.Mensaje = new BodyDto() { Format = EnumBodyMail.Html, Value = fmt };

                _correo.enviarCorreo(email, smtp);
                ; return Ok(responseDTO.Success(responseDTO,result));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_incidenciaAsignaciones obj)
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
