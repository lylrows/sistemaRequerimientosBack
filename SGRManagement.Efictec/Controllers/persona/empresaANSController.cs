using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.persona;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.persona;

namespace SGRManagement.Efictec.Controllers.persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class empresaANSController : ControllerBase
    {
        private IEmpresaANSLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public empresaANSController(IEmpresaANSLogic t_logic)
        {
            _logic = t_logic;
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
        [Route("cambioAnsDescartado/{id:int}")]
        public IActionResult cambioAnsDescartado(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.cambioAnsDescartado(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("getANSByIdEmpresa/{id:int}")]
        public IActionResult getANSByIdEmpresa(int id)
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getANSByIdEmpresa(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("actualizarFechaMaximaDeAtencion")]
        public IActionResult getIncidenciaHorarios()
        {

            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.getIncidenciaHorarios()));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_empresaANS obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_empresaANS obj)
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
