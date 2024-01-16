using System;
using System.Threading;
using Logica.Negocio.Interfaces.Logic.configuracion;
using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Datos.Mapeo.Base.Datos.configuracion;

namespace SGRManagement.Efictec.Controllers.configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class parametrosController : ControllerBase
    {
        private IParametrosLogic _parametros;
        public ResponseDTO responseDTO = new ResponseDTO();
        public parametrosController(IParametrosLogic t_parametros)
        {
            _parametros = t_parametros;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametros.GetList()));
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
                ; return Ok(responseDTO.Success(responseDTO, _parametros.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }


        [HttpPost]
        public IActionResult Insert([FromBody] t_parametros obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametros.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] t_parametros obj)
        {
            try
            {
                ; return Ok(responseDTO.Success(responseDTO, _parametros.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(responseDTO.Failed(responseDTO, e.Message));
            }
        }
    }
}
