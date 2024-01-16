using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.incidencia;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.incidencia;
using Modelos.Datos.Solicitud.DTO;

namespace SGRManagement.Efictec.Controllers.incidencia
{
    [Route("api/[controller]")]
    [ApiController]
    public class incidenciaSolucionPalabrasClaveController : ControllerBase
    {
        private IIncidenciaSolucionPalabrasClaveLogic _logic;
        public ResponseDTO responseDTO = new ResponseDTO();
        public incidenciaSolucionPalabrasClaveController(IIncidenciaSolucionPalabrasClaveLogic t_logic)
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

        [HttpPost]
        public IActionResult Insert([FromBody] t_incidenciaSolucionPalabrasClave obj)
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


        [HttpPost]
        [Route("InsertTags")]
        public IActionResult InsertTags([FromBody] tagsObjDTO obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _logic.InsertTags(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_incidenciaSolucionPalabrasClave obj)
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
