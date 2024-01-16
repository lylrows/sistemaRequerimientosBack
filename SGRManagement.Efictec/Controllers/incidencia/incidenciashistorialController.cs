using Microsoft.AspNetCore.Mvc;
using System;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/incidenciashistorial")]
    [ApiController]
    public class incidenciashistorialController : ControllerBase
    {
        private IIncidenciashistorialLogic _incidenciashistorial;
        public ResponseDTO _ResponseDTO;
        public incidenciashistorialController(IIncidenciashistorialLogic incidenciashistorial)
        {
            _incidenciashistorial = incidenciashistorial;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _incidenciashistorial.GetList()));
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
                return Ok(_ResponseDTO.Success(_ResponseDTO, _incidenciashistorial.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] incidenciasHistorial obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _incidenciashistorial.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] incidenciasHistorial obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _incidenciashistorial.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] incidenciasHistorial obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _incidenciashistorial.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
