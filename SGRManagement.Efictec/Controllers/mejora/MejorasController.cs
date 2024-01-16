using Microsoft.AspNetCore.Mvc;
using System;
using Logica.Negocio.Interfaces.Logic.mejoras;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.mejora;
using System.Threading;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.mejora
{
    [Route("api/[controller]")]
    [ApiController]
    public class MejorasController : ControllerBase
    {
        private IMejorasLogic _mejoras;
        public ResponseDTO _ResponseDTO;
        public MejorasController(IMejorasLogic mejoras)
        {
            _mejoras = mejoras;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] t_mejoras obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                obj.fechaActualiza = null;
                obj.fechaAtencion = null;
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("getTicketsAsosciados")]
        public IActionResult getTicketsAsosciados([FromBody] ticketsAsosciadosFilter obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.getTicketsAsosciados(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_mejoras obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                obj.fechaAtencion = null;
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] t_mejoras obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("obtenerUsuariosParaAsignarByMejora/{id:int}")]
        public IActionResult obtenerUsuariosParaAsignarByMejora(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                ; return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.obtenerUsuariosParaAsignarByMejora(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("obtenerMejoraPorIdUsuario")]
        public IActionResult obtenerMejoraPorIdUsuario([FromBody] filterDataDTO obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.obtenerMejoraPorIdUsuario(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }      


        [HttpGet]
        [Route("getMejoraById/{id:int}")]
        public IActionResult getMejoraById(int id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.getMejoraById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("obtenerMejoraPorIdClienteEmpresa")]
        public IActionResult obtenerMejoraPorIdClienteEmpresa([FromBody] int obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _mejoras.obtenerMejoraPorIdClienteEmpresa(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
